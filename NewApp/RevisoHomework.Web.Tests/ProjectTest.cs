using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevisoHomework.Interface.Controllers;
using RevisoHomework.Interface.Facade.Contracts.DTO;
using RevisoHomework.Web.Tests.Utile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RevisoHomework.Web.Tests
{
    [TestClass]
    public class ProjectTest
    {
        [TestMethod]
        public void Create_Check_Befor_and_after_Be_The_Same()
        {
            using (var scope = new TransactionScope())
            {
                var container = GetContainerProvicder.GetContainer();
                container.Kernel.ComponentModelBuilder.AddContributor(new PerRequestChanger());

                var prjDto = new ProjectCreateDTO()
                {
                    Code = "1",
                    Comment = "coment1",
                    Price = 100,
                    Title = "project1",
                    Customer_Id = 1

                };

                var controller = container.Resolve<ProjectsController>();

                var resultAfterCreateDTO = controller.Post(prjDto);

                var resultAfterGet = controller.GetById(resultAfterCreateDTO.Id);


                Assert.AreEqual(resultAfterGet.Result.Title, prjDto.Title);
            }

        }
        [TestMethod]
        public void Create_Check_If_customer_IsNull()
        {
            using (var scope = new TransactionScope())
            {
                var container = GetContainerProvicder.GetContainer();
                container.Kernel.ComponentModelBuilder.AddContributor(new PerRequestChanger());
                             
                var prjDto = new ProjectCreateDTO()
                {
                    Code = "1",
                    Comment = "coment1",
                    Price = 100,
                    Title = "project1",
                    Customer_Id = 1

                };

                var controller = container.Resolve<ProjectsController>();

                var resultAfterCreateDTO = controller.Post(prjDto);

                var resultAfterGet = controller.GetById(resultAfterCreateDTO.Id);

                Assert.IsNull(resultAfterGet.Result.Customer_Id);
            }

        }

        [TestMethod] 
        public void Create_Project_Wthiout_Customer_should_throw_Exception()
        {
            using (var scope = new TransactionScope())
            {
                var container = GetContainerProvicder.GetContainer();
                container.Kernel.ComponentModelBuilder.AddContributor(new PerRequestChanger());

                var prjDto = new ProjectCreateDTO()
                {
                    Code = "1",
                    Comment = "coment1",
                    Price = 100,
                    Title = "project1",
                    Customer_Id = 50

                };

                try
                {
                    var controller = container.Resolve<ProjectsController>();

                    var resultAfterCreateDTO = controller.Post(prjDto);
                    Assert.IsNotNull(resultAfterCreateDTO);
                }
                catch (Exception e)
                {
                    Assert.Fail(
                    string.Format("Insert project Without cutomer Or Forenkey {0} caught: {1}",
                    e.GetType(), e.Message)
                    );
                }


            }

        }
    }
}
