﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace RevisoHomework.Web.Infrastructure
{
    public class CastleControllerActivator : IHttpControllerActivator
    {
        private WindsorContainer _container;
        public CastleControllerActivator(WindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController) _container.Resolve(controllerType);
        }
    }
}