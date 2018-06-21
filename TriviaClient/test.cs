using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTriviaClient
{
    class test
    {
        public void foo()
        {
            string MsgFromServer = "121305rabea1005suray0504user15";

            int numOfUsers = Int32.Parse(MsgFromServer.Substring(3, 1));

            if (numOfUsers == 0)
            {

            }
            else
            {
                Dictionary<string, int> Users = new Dictionary<string, int>();

                int firstUserNameSizeIndex = 4;
                string userName;
                int NameSize;
                int sizeSum = 0;
                int UserScore;

                for (int i = 0; i < numOfUsers; i++)
                {
                    NameSize = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + sizeSum + i * 4, 2));
                    userName = MsgFromServer.Substring(firstUserNameSizeIndex + 2 + sizeSum + i * 4, NameSize);

                    sizeSum += NameSize;

                    UserScore = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + 2 + sizeSum + i * 4, 2));

                    Users[userName] = UserScore;
                }

                // Send usernames list to the function

            }
        }
    }
}
