﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FellowshipOne.Api.Model;
using System.Xml;
using System.Xml.Serialization;

namespace FellowshipOne.Api.Groups.Model {
    [Serializable]
    [XmlRoot("member")]
    public partial class Member : APIModel {
        private ParentNamedObject _group = new ParentNamedObject();
        [XmlElement("group")]
        public ParentNamedObject Group {
            get { return _group; }
            set { _group = value; }
        }

        private ParentNamedObject _person = new ParentNamedObject();
        [XmlElement("person")]
        public ParentNamedObject Person {
            get { return _person; }
            set { _person = value; }
        }

        private ParentNamedObject _memberType = new ParentNamedObject();
        [XmlElement("memberType")]
        public ParentNamedObject MemberType {
            get { return this._memberType; }
            set { this._memberType = value; }
        }

        [XmlElement("createdDate")]
        public DateTime? CreatedDate { get; set; }

        private ParentObject _createdByPerson = new ParentObject();
        [XmlElement("createdByPerson")]
        public ParentObject CreatedByPerson {
            get { return this._createdByPerson; }
            set { this._createdByPerson = value; }
        }

        [XmlElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set; }

        private ParentObject _lastUpdatedByPerson = new ParentObject();
        [XmlElement("lastUpdatedByPerson")]
        public ParentObject LastUpdatedByPerson {
            get { return this._lastUpdatedByPerson; }
            set { this._lastUpdatedByPerson = value; }
        }
    }

    [Serializable]
    [XmlRoot("members")]
    public class MemberCollection : Collection<Member> {
        public MemberCollection() { }
        public MemberCollection(List<Member> members) {
            if (members != null) {
                this.AddRange(members);
            }
        }
    }
}
