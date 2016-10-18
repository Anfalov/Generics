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
        StorageOfID.StorageOfID Storage;
        StorageOfID.Example a;
        IEnumerable<KeyValuePair<Guid, StorageOfID.Example>> Pairs;
        [TestInitialize()]
        public void Initialize()
        {
            Storage = new StorageOfID.StorageOfID();
            Storage.Create<StorageOfID.SecondExample>();
            Storage.Create<StorageOfID.Example>();
            Storage.Create<StorageOfID.Example>();
            a = Storage.Create<StorageOfID.Example>();
            Pairs = Storage.PairsByType<StorageOfID.Example>();
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
            foreach (var item in Pairs)
            {
                Assert.AreEqual(0, item.Value.X);
                Assert.AreEqual(typeof(StorageOfID.Example), item.Value.GetType());
            }
        }
        [TestMethod]
        public void PairsByType_Should_Return_RightAmountOfPairs()
        {
            int i = 0;
            foreach (var item in Pairs)
                i++;
            Assert.AreEqual(3, i);
        }
        [TestMethod]
        public void ObjectByGuid_Should_Return_CorrectAnswer()
        {
            foreach (var item in Pairs)
                Assert.AreEqual(0, Storage.ObjectByGuid<StorageOfID.Example>(item.Key).X);
        }
        [TestMethod]
        public void ObjectByGuid_Should_Return_Null_WhenType_T_IsNotTypeOfObject()
        {
            foreach (var item in Pairs)
                Assert.AreEqual(null, Storage.ObjectByGuid<StorageOfID.SecondExample>(item.Key));
        }
        [TestMethod]
        public void ObjectByGuid_Should_Return_Null_When_ID_IsNotCorrect()
        {
            foreach (var item in Pairs)
                Assert.AreEqual(null, Storage.ObjectByGuid<StorageOfID.Example>(Guid.NewGuid()));
        }
    }
}
