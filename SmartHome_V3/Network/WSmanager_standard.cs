using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace SmartHome_V3
{
    delegate void WSMessage(string e);
    class WSController_standard
    {
        /// <summary>
        /// web socket server
        /// </summary>
        WebSocketServer wss;
        public static WSMessage SendToSession = null;
        /// <summary>
        /// delegate for print
        /// </summary>
        public static UpdateMessage um;
        public WSController_standard(int port, UpdateMessage umm)
        {
            // Start a websocket server at port 8001
            wss = new WebSocketServer(port);
            um = umm;
            // Add the Echo websocket service
            wss.AddWebSocketService<Android>("/Android");
            wss.AddWebSocketService<Android>("/Arduino");
            // Start the server
            wss.Start();
        }


        /// <summary>
        /// update and make a tunal for output
        /// </summary>
        /// <param name="um"></param>
        public void ImplementDelegate(UpdateMessage umm)
        {
            um = umm;
        }
        /// <summary>
        /// stop the server
        /// </summary>
        public void StopServer()
        {
            wss.Stop();
        }
        public string getIDs()
        {
            throw new NotImplementedException();
            string ids = "Function not implement yet!";
            //wsServer.GetSessions
            //foreach (SuperSocket.SocketBase.AppServer session in wsServer.GetAllSessions) {

            //}
            return ids;
        }
        /// <summary>
        /// send message to select session
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            

            if (SendToSession == null)
            {
                um("No Device Connect, cannot make operate.");

            }
            else
            {
                SendToSession(message);
                um("Message send success.");
            }
        }


    }
    class Arduino : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            // Retrieve message from client
            string msg = e.Data;
            Send("Echo: "+msg);
            WSController_standard.um(msg);
        }
        protected override void OnOpen()
        {
            WSController_standard.um("Arduino device has connected.");
            WSController_standard.SendToSession = Send;
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
        }
    }
    class Android : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            // Retrieve message from client
            try
            {
                string msg = e.Data;
                msg = InstructionExcuteHelper.ExcuteMsg(msg);
                if(msg != "")
                Send(msg);
            }
            catch (Exception)
            {

            }
            
        }
        protected override void OnOpen()
        {
            WSController_standard.um("Android device has connected. ID: "+ this.ID);
            WSController_standard.SendToSession = Send;
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
        }

        
    }
}
