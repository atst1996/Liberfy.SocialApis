﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SocialApis.Mastodon
{
    [DataContract]
    public class Emoji
    {
        [DataMember(Name = "shortcode")]
        public string ShortCode { get; private set; }

        [DataMember(Name = "static_url")]
        public string StaticUrl { get; private set; }

        [DataMember(Name = "url")]
        public string Url { get; private set; }

        [DataMember(Name = "visible_in_picker")]
        public bool VisibleInPicker { get; private set; }
    }
}
