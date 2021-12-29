using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<UnitofWork>().As<IUnitofWork>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().InstancePerLifetimeScope();

            builder.RegisterType<CarManager>().As<ICarService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCarDal>().As<ICarDal>().InstancePerLifetimeScope();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().InstancePerLifetimeScope();

            builder.RegisterType<ColorManager>().As<IColorService>().InstancePerLifetimeScope();
            builder.RegisterType<EfColorDal>().As<IColorDal>().InstancePerLifetimeScope();
            
            builder.RegisterType<CompanyManager>().As<ICompanyService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().InstancePerLifetimeScope();

            // builder.RegisterType<CreditCardManager>().As<ICreditCardService>().InstancePerLifetimeScope();
            // builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>().InstancePerLifetimeScope();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().InstancePerLifetimeScope();

            builder.RegisterType<FakeFindeksManager>().As<IFindeksService>().InstancePerLifetimeScope();
            builder.RegisterType<EfFindeksDal>().As<IFindeksDal>().InstancePerLifetimeScope();

            // builder.RegisterType<FakePaymentManager>().As<IPaymentService>().InstancePerLifetimeScope();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().InstancePerLifetimeScope();

            builder.RegisterType<RentalManager>().As<IRentalService>().InstancePerLifetimeScope();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().InstancePerLifetimeScope();

            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}