﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ApiRestful.Business.Interfaces;
using ApiRestful.Business.Notications;

namespace ApiRestful.Api.v1.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly INotify _notify;

        public readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }

        protected bool UsuarioAutenticado { get; set; }

        public MainController(INotify notify,
                              IUser appUser)
        {
            _notify = notify;
            AppUser = appUser;

            if (AppUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }

        }


        protected ActionResult FormattedResponse(Object result = null)
        {
            if (HasNoErros())
            { 
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notify.GetAllNotifications().Select(n => n.Mesage)
            }); 


        }


        protected ActionResult FormattedResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelState(modelState);

            return FormattedResponse();
        }

        protected void NotifyInvalidModelState(ModelStateDictionary modelState)
        {
            foreach (var error in modelState.Values.SelectMany(e => e.Errors))
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected bool HasNoErros()
        {
            return !_notify.HaveNotifications();
        }

        protected void NotifyError(string mesage)
        {
            _notify.Handle(new Notify(mesage));
        }

    }
}
