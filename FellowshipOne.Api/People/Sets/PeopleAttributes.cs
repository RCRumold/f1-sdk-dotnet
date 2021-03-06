﻿
using RestSharp;
using System.Collections.Generic;
using FellowshipOne.Api.People.Model;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Text;

namespace FellowshipOne.Api.People.Sets {
    public class PeopleAttributes : ApiSet<PersonAttribute> {
        private const string CHILD_LIST_URL = "/v1/people/{0}/attributes";
        private const string CREATE_PERSON_ATTRIBUTE_URL = "/v1/people/{0}/attributes";
        private const string EDIT_URL = "/v1/people/{0}/attributes/{1}";
        private string _createUrl = string.Empty;
        private string _editUrl = string.Empty;

        public PeopleAttributes(OAuthTicket ticket, string baseUrl) : base(ticket, baseUrl, ContentType.XML) { }

        protected override string EditUrl { get { return this._editUrl; } }
        protected override string GetChildListUrl { get { return CHILD_LIST_URL; } }
        protected override string CreateUrl {
            get {
                return _createUrl;
            }
        }

        public PersonAttributeCollection Get(int personID) {
            var request = CreateRestRequest(Method.GET, string.Format(CHILD_LIST_URL, personID));
            var item = ExecuteCustomRequest<PersonAttributeCollection>(request);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(item.Content))) {
                XmlSerializer serializer = new XmlSerializer(typeof(PersonAttributeCollection), new XmlRootAttribute("attributes"));

                var result = serializer.Deserialize(stream) as PersonAttributeCollection;
                return result;
            }
        }

        public PersonAttribute CreateForPerson(int personID, Model.PersonAttribute entity, out string requestXml) {
            this._createUrl = string.Format(CREATE_PERSON_ATTRIBUTE_URL, personID);
            return Create(entity, out requestXml);
        }

        public PersonAttribute UpdateForPerson(int personID, Model.PersonAttribute entity) {
            this._editUrl = string.Format(EDIT_URL, personID, entity.APIModelID);
            return Update(entity, entity.APIModelID);
        }

        public bool DeleteForPerson(int personID, Model.PersonAttribute entity) {
            this._editUrl = string.Format(EDIT_URL, personID, entity.APIModelID);
            return Delete(entity.APIModelID);
        }
    }
}
