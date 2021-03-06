﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Zero.Data;
using Zero.Mvc.Manage.Controllers.Cates;
using Zero.Mvc.Manage.Controllers.Products;
using Zero.Mvc.Manage.Controllers.Trades;
using Zero.Mvc.Manage.Controllers.News;
using Zero.Mvc.Manage.Controllers.Customs;
using Zero.Mvc.Manage.Controllers.Upload;
using Zero.Mvc.Manage.Controllers.Sys;
using Zero.Mvc.Manage.Controllers.Users;
using Zero.Service.Cates;
using Zero.Service.Products;
using Zero.Service.News;
using Zero.Service.Trades;
using Zero.Service.Customs;
using Zero.Service.Upload;
using Zero.Service.Sys;
using Zero.Service.Users;
using Zero.Domain.Cates;



namespace Zero.Mvc.Manage.Infrastructure
{
    public class DependencyRegistrar
    {
        public void Registrar()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<EfDbContext>().As<IDbContext>().InstancePerHttpRequest();

            builder.RegisterType<CateController>();
            builder.RegisterType<CateAttrController>();
            builder.RegisterType<AttrController>();
            builder.RegisterType<AttrValueController>();
            builder.RegisterType<ProductController>();
            builder.RegisterType<OrderController>();
            builder.RegisterType<NewsController>();
            builder.RegisterType<CustomController>();
            builder.RegisterType<PhotoController>();
            builder.RegisterType<CodeController>();
            builder.RegisterType<UserController>();

            //service
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType<CateService>().As<ICateService<Cate>>().InstancePerHttpRequest();
            builder.RegisterType<CateAttrService>().As<ICateAttrService>().InstancePerHttpRequest();
            builder.RegisterType<AttrService>().As<IAttrService>().InstancePerHttpRequest();
            builder.RegisterType<AttrValueService>().As<IAttrValueService>().InstancePerHttpRequest();

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerHttpRequest();

            builder.RegisterType<CartService>().As<ICartService>().InstancePerHttpRequest();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerHttpRequest();

            builder.RegisterType<NewsService>().As<INewsService>().InstancePerHttpRequest();

            builder.RegisterType<CustomService>().As<ICustomService>().InstancePerHttpRequest();

            builder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerHttpRequest();

            builder.RegisterType<CodeService>().As<ICodeService>().InstancePerHttpRequest();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();

            // then
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}