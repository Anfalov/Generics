using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageOfIDTest
{
    [TestClass]
    public class StorageOfIDTest
    {
        StorageOfID.StorageOfID storage;
        StorageOfID.Example a;
        IEnumerable<KeyValuePair<Guid, StorageOfID.Example>> pairs;
        [TestInitialize()]
        public void Initialize()
        {
            storage = new StorageOfID.StorageOfID();
            storage.Create<StorageOfID.SecondExample>();
            storage.Create<StorageOfID.Example>();
            storage.Create<StorageOfID.Example>();
            a = storage.Create<StorageOfID.Example>();
            pairs = storage.PairsByType<StorageOfID.Example>();
        }
        [TestMethod]
        public void Create_Should_Return_ObjectOfType_T()
        {
            Assert.AreEqual(typeof(StorageOfID.Example), a.GetType());
            Assert.AreEqual(0, a.X);
        }
        [TestMethod]
        public void PairsByType_Should_Return_CorrectPairs()
        {
            foreach (var item in pairs)
            {
                Assert.AreEqual(0, item.Value.X);
                Assert.AreEqual(typeof(StorageOfID.Example), item.Value.GetType());
            }
        }
        [TestMethod]
        public void PairsByType_Should_Return_RightAmountOfPairs()
        {
            int i = 0;
            foreach (var item in pairs)
                i++;
            Assert.AreEqual(3, i);
        }
        [TestMethod]
        public void ObjectByGuid_Should_Return_CorrectAnswer()
        {
            foreach (var item in pairs)
                Assert.AreEqual(0, storage.ObjectByGuid<StorageOfID.Example>(item.Key).X);
        }
        [TestMethod]
        public void ObjectByGuid_Should_Return_Null_WhenType_T_IsNotTypeOfObject()
        {
            foreach (var item in pairs)
                Assert.AreEqual(null, storage.ObjectByGuid<StorageOfID.SecondExample>(item.Key));
        }
        [TestMethod]
        public void ObjectByGuid_Should_Return_Null_When_ID_IsNotCorrect()
        {
            foreach (var item in pairs)
                Assert.AreEqual(null, storage.ObjectByGuid<StorageOfID.Example>(Guid.NewGuid()));
        }
    }
}
