using CMS.Bll;
using CMS.Bll.Concrete.Company;
using CMS.Bll.Concrete.Contact;
using CMS.Bll.Concrete.News;
using CMS.Bll.Concrete.NewsMember;
using CMS.Bll.Concrete.Pages;
using CMS.Bll.Concrete.Reference;
using CMS.Bll.Concrete.Slider;
using CMS.Bll.Concrete.User;
using CMS.Dal.Concrete.EntityFramework.Repository;
using CMS.Interfaces;
using CMS.Interfaces.Company;
using CMS.Interfaces.Contact;
using CMS.Interfaces.News;
using CMS.Interfaces.NewsMember;
using CMS.Interfaces.Pages;
using CMS.Interfaces.Reference;
using CMS.Interfaces.Slider;
using CMS.Interfaces.User;
using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS.MvcUI.NinjectController
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBllBindings();
        }

        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IMenuService>()
                .To<MenuManager>()
                .WithConstructorArgument("menuDal",
                new EFMenuDal());

            _ninjectKernel.Bind<IUserService>()
                 .To<UserManager>()
                 .WithConstructorArgument("userDal",
                 new EFUserDal());

            _ninjectKernel.Bind<ICompanyService>()
               .To<CompanyManager>()
               .WithConstructorArgument("companyDal",
               new EFCompanyDal());

            _ninjectKernel.Bind<IReferenceService>()
               .To<ReferenceManager>()
               .WithConstructorArgument("referenceDal",
               new EFReferenceDal());

            _ninjectKernel.Bind<ISliderService>()
             .To<SliderManager>()
             .WithConstructorArgument("sliderDal",
             new EFSliderDal());

            _ninjectKernel.Bind<IBulletinMemberService>()
             .To<BulletinMemberManager>()
             .WithConstructorArgument("bulletinMemberDal",
             new EFBulletinMemberDal());

            _ninjectKernel.Bind<INewsService>()
            .To<NewsManager>()
            .WithConstructorArgument("newsDal",
            new EFNewsDal());

            _ninjectKernel.Bind<IContactService>()
           .To<ContactManager>()
           .WithConstructorArgument("contactDal",
           new EFContactDal());

            _ninjectKernel.Bind<IPagesService>()
          .To<PagesManager>()
          .WithConstructorArgument("pagesDal",
          new EFPagesDal());

            _ninjectKernel.Bind<IProductService>()
        .To<ProductManager>()
        .WithConstructorArgument("productDal",
        new EFProductDal());

            _ninjectKernel.Bind<ICategoryService>()
    .To<CategoryManager>()
    .WithConstructorArgument("categoryDal",
    new EFCategoryDal());

            _ninjectKernel.Bind<ISocialIconService>()
  .To<SocialIconManager>()
  .WithConstructorArgument("socialIconDal",
  new EFSocialIconDal());

            _ninjectKernel.Bind<IRoleService>()
.To<RoleManager>()
.WithConstructorArgument("roleDal",
new EFRoleDal());

            _ninjectKernel.Bind<IBulletinService>()
.To<BulletinManager>()
.WithConstructorArgument("bulletinDal",
new EFBulletinDal());

            _ninjectKernel.Bind<IJobService>()
.To<JobManager>()
.WithConstructorArgument("jobDal",
new EFJobDal());

            _ninjectKernel.Bind<IJobUserService>()
.To<JobUserManager>()
.WithConstructorArgument("jobUserDal",
new EFJobUserDal());
        }


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}