using lppa.equipo._4.Data.Model;
using lppa.equipo._4.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lppa.equipo._4.Website.Services
{
        public class Logger
        {
            private Logger()
            {
            }
            public readonly static Logger Instance = new Logger();
            public void LogException(Exception exception)
            {
                try
                {
                    string userId = null;
                    try { userId = HttpContext.Current.User.Identity.Name; }
                    catch {/* Enviar un correo electrónico al webmaster */ }

                    
                    var error = new Error()
                    {
                        UserId = userId,
                        Exception = exception.GetType().FullName,
                        Message = exception.Message,
                        Everything = exception.ToString(),
                        IpAddress = HttpContext.Current.Request.UserHostAddress,
                        UserAgent = HttpContext.Current.Request.UserAgent,
                        PathAndQuery = HttpContext.Current.Request.Url == null ? "" : HttpContext.Current.Request.Url.PathAndQuery,
                        HttpReferer = HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.PathAndQuery,

                    };
                    var db = new BaseDataService<Error>();
                    db.Create(error);
                }
                catch (Exception ex)
                {

                  /* Enviar un correo electrónico al webmaster */
            }
        }
        }
    }