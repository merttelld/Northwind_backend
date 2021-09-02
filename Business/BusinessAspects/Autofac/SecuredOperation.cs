using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //Bir metni senin belirttiğin karaktere göre ayırıp arraye atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                //Eğer claimlerinin içinde ilgili rol varsa return et yani metodu çalıştırmaya devam et
                if (roleClaims.Contains(role))
                {
                    return; 
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //Aksi halde yetkin yok hatası ver demek
        }
    }
}
