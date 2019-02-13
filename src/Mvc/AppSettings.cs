// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

namespace Everis.Polar.Mvc.Settings
{
    public class AppSettings
    {
        public string AppName { get; set; }        
        public Logging Logging { get; set; }
        public Services Services { get; set; }
    }

    public class Services
    {
        public string BaseUrl { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
