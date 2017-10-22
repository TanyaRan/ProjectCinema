﻿using Ganss.XSS;

namespace TRan.CinemaUniverse.Web.Infrastructure.Santizing
{
    public class HtmlSanitizerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}