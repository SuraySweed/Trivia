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
            string MsgFromServer = "1040002000105suray000205rabea";
            int numOfRooms = Int32.Parse(MsgFromServer.Substring(3, 4));
            // rooms <id, name>
            Dictionary<string, string> Rooms = new Dictionary<string, string>();

            int firstRoomIDIndex = 7;
            int firstRoomNameSizeIndex = 11;
            string roomID;
            int roomNameSize = 0;
            string roomName;
            int roomNameSizeSum = 0;

            for (int i = 0; i < numOfRooms; i++)
            {
                roomNameSize = Int32.Parse(MsgFromServer.Substring(firstRoomNameSizeIndex + roomNameSizeSum + i * 4 + i * 2, 2));
               

                roomName = MsgFromServer.Substring(firstRoomNameSizeIndex + 2 + roomNameSizeSum + i * 4 + i * 2, roomNameSize);
                roomID = MsgFromServer.Substring(firstRoomIDIndex + i * 4 + i * 2 + roomNameSizeSum, 4);
                roomNameSizeSum += roomNameSize;
                Rooms.Add(roomID, roomName);
            }
        }
    }
}
