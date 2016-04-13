using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class UpdatingModule
    {
        private static UpdatingModule _instance = null;

        public static UpdatingModule Instance => _instance ?? (_instance = new UpdatingModule());

        public void UpdateStructures(GameData data)
        {
            throw new NotImplementedException();
        }

        public void AddNewQuestion(string text)
        {
            throw new NotImplementedException();
        }

        public void AddNewPerson(string name)
        {
            throw new NotImplementedException();
        }
    }
}
