using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSender.lib.Services;
using MailSender.lib.Entityes;

namespace MailSender.lib.Tests.Services.InMemory
{
    [TestClass]
    public class InMemoryRecipientsDataProviderTests
    {
        [AssemblyInitialize]
        public static void TestAssembly_Initialize(TestContext context)
        {
            //1
        }

        [ClassInitialize]
        public static void TestClass_Initialize(TestContext context)
        {
            //2
        }

        [TestInitialize]
        public void Test_Initialize()
        {
            //4
        }

        [TestCleanup]
        public void Test_Cleanup()
        {
            //6
        }

        [ClassCleanup]
        public static void TestClass_Cleanup()
        {
            //7
        }

        [AssemblyCleanup]
        public static void TestAssembly_Cleanup()
        {
            //8
        }

        public InMemoryRecipientsDataProviderTests()
        {
            //3
        }

        [TestMethod]
        public void CreateNewRecipientInEmptyProvider()
        {
            //5
            var data_provider = new InMemoryRecipientsDataProvider();

            var expected_recipient_name = "Получатель 1";
            var expected_recipient_address = "recipient1@server.com";
            var expected_id = 1;

            var new_recipient = new Recipient
            {
                Name = expected_recipient_name,
                Address = expected_recipient_address
            };

            data_provider.Create(new_recipient);
            var actual_id = new_recipient.Id;

            var actual_recipient = data_provider.GetById(expected_id);

            Assert.AreEqual(expected_id, actual_id);
            Assert.AreEqual(expected_recipient_name, actual_recipient.Name);
            Assert.AreEqual(expected_recipient_address, actual_recipient.Address);

            // StringAssert. работа со строками
            // CollectionAssert. работа с коллекциями

            if (expected_id != actual_id)
                throw new AssertFailedException("Идентификаторы объектов не совпадают");

        }
    }
}
