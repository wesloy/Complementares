using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Algar.Dynamics.Framework.CRM;
using System.IO;

namespace email_dynamics
{
    public class email_dynamics
    {


        #region Atributos
        public List<string> Para { get; set; }
        public List<string> Cc { get; set; }
        public List<string> CcO { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public List<string> Anexos { get; set; }
        #endregion

        private static Connection service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assunto">Obrigatório. Título do e-mail.</param>
        /// <param name="corpoEmail">Obrigatório. Corpo do e-mail, assunto em si.</param>
        /// <param name="listaPara">Obrigatótio. Lista de destinatário.</param>
        /// <param name="listaCC">Facultativo. Lista de destinatário.</param>
        /// <param name="listaCCo">Facultativo. Lista de destinatário.</param>
        /// <param name="caminhoAnexos">Facultativo. Lista de destinatário.</param>
        public bool envio(string assunto, string corpoEmail, List<string> listaPara, List<string> listaCC = null, List<string> listaCCo = null, List<string> caminhoAnexos = null)
        {
            try
            {
                service = new Connection("Hhw8hHV4DGVQI0IiAGTBJ3lfx1758i0A/8/17pEXNnGrYD+i336b1sV3I9uG3RmpUc7GvkPtYllKIRATMJ0eqKJGkAln1dqvXtxfpsWNulaGtznDupYDiD+VY9mvLc30/JYixs5yxawoKasuK1pM32Ot27P2+5u8N+G093LfdN0=");


                EntityCollection from = new EntityCollection();
                from.Entities.Add(new Entity("queue", new Guid("6991b72e-8587-e911-a2c9-00155d329c28"))); //fila dentro do dynamics

                EntityCollection ParaCollection = new EntityCollection();
                EntityCollection ccCollection = new EntityCollection();
                EntityCollection ccOCollection = new EntityCollection();
                Entity anexo = new Entity("activitymimeattachment");

                //LISTA PARA
                if (listaPara != null)
                {
                    foreach (string para in listaPara)
                    {
                        if (para != "" && para != null)
                        {
                            QueryExpression qe = new QueryExpression("contact");
                            qe.Criteria = new FilterExpression();
                            qe.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, para);
                            Entity paraContact = service.RetrieveMultiple(qe).Entities.FirstOrDefault();

                            if (paraContact == null)
                            {
                                Entity contact = new Entity("contact");
                                contact["emailaddress1"] = para;
                                contact["lastname"] = para;

                                ParaCollection.Entities.Add(new Entity("contact", service.Create(contact)));
                            }
                            else
                            {
                                ParaCollection.Entities.Add(paraContact);
                            }
                        }

                    }
                }

                //LISTA CC
                if (listaCC != null)
                {
                    foreach (string cc in listaCC)
                    {

                        if (cc != "" && cc != null)
                        {

                            QueryExpression qe = new QueryExpression("contact");
                            qe.Criteria = new FilterExpression();
                            qe.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, cc);
                            Entity ccContact = service.RetrieveMultiple(qe).Entities.FirstOrDefault();

                            if (ccContact == null)
                            {
                                Entity contact = new Entity("contact");
                                contact["emailaddress1"] = cc;
                                contact["lastname"] = cc;

                                ccCollection.Entities.Add(new Entity("contact", service.Create(contact)));
                            }
                            else
                            {
                                ccCollection.Entities.Add(ccContact);
                            }
                        }
                    }
                }


                //LISTA CCo
                if (listaCCo != null)
                {

                    foreach (string ccO in listaCCo)
                    {
                        if (ccO != "" && ccO != null)
                        {


                            QueryExpression qe = new QueryExpression("contact");
                            qe.Criteria = new FilterExpression();
                            qe.Criteria.AddCondition("emailaddress1", ConditionOperator.Equal, ccO);
                            Entity ccOContact = service.RetrieveMultiple(qe).Entities.FirstOrDefault();

                            if (ccOContact == null)
                            {
                                Entity contact = new Entity("contact");
                                contact["emailaddress1"] = ccO;
                                contact["lastname"] = ccO;

                                ccOCollection.Entities.Add(new Entity("contact", service.Create(contact)));
                            }
                            else
                            {
                                ccOCollection.Entities.Add(ccOContact);
                            }
                        }
                    }
                }

                Entity email = new Entity("email");
                email["to"] = EntityCollectionToActivyPartyCollection(ParaCollection);
                email["cc"] = EntityCollectionToActivyPartyCollection(ccCollection);
                email["cco"] = EntityCollectionToActivyPartyCollection(ccOCollection);
                email["from"] = EntityCollectionToActivyPartyCollection(from);
                email["subject"] = assunto;
                email["description"] = corpoEmail.Replace("\r\n","<br />");
                Guid EmailId = service.Create(email);

                //LISTA DE ANEXOS
                if (caminhoAnexos != null)
                {
                    foreach (string atachado in caminhoAnexos)
                    {
                        if (atachado != null && atachado != "")
                        {
                            anexo["objectid"] = new EntityReference("email", EmailId);
                            anexo["objecttypecode"] = 4202;
                            anexo["body"] = Convert.ToBase64String(File.ReadAllBytes(atachado));
                            anexo["filename"] = Path.GetFileName(atachado);
                            service.Create(anexo);
                        }
                    }
                }


                //MONTAGEM E-MAIL
                SendEmailRequest sendEmailreq = new SendEmailRequest
                {
                    EmailId = EmailId,
                    IssueSend = true
                };

                //ENVIO
                service.Execute(sendEmailreq);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new InvalidPluginExecutionException(e.Message);

            }

        }

        private static EntityCollection EntityCollectionToActivyPartyCollection(EntityCollection entityCollection)
        {
            EntityCollection activyPartyCollection = new EntityCollection();
            foreach (Entity entity in entityCollection.Entities)
            {
                Entity finalEntity = new Entity("activityparty", Guid.NewGuid());
                finalEntity["partyid"] = entity.ToEntityReference();
                activyPartyCollection.Entities.Add(finalEntity);
            }
            return activyPartyCollection;
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

}

