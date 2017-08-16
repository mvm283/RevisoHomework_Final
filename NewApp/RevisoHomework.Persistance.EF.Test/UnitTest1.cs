using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using RevisoHomework.Domain.Model;
using System.Linq;
using Accounting.Persistance.EF.Repositories;

namespace RevisoHomework.Persistance.EF.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = new RevisoHomeworkDbContext();
            var projectRepo=new ProjectRepository(context)
            using (var scope = new TransactionScope())
            { 
                    var cstmrModel = new CustomerModel()
                    {
                        Code = "1",
                        Title = "Customer1",
                        Comment = "coment1",
                        Mobile = "654321",
                        Phone = "123456",
                        Address = "Address1",
                    };
                    var prjModel = new ProjectModel()
                    {
                        Code = "1",
                        Comment = "coment1",
                        Price = 100,
                        Title = "project1",
                        Customer = cstmrModel

                    };

                    var prj = projectRepo..Create(prjModel);

                    var resultAfterCreateDTO = controller.Post(prjDto);

                    var resultAfterGet = controller.GetById(resultAfterCreateDTO.Id);


                    Assert.AreEqual(resultAfterGet.Result.Title, prjDto.Title);
                    Assert.IsNull(resultAfterGet.Result.Customer_Id);
                } 
        }

    }
}
