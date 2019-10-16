using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net;
using System.Text;
using System.Threading.Tasks;
using SuperWebSocket;
//using WebSocketSharp.Server;

namespace SmartHome_V3
{
    class WSController_super
    {

        WebSocketSession currentsession;


        /// <summary>
        /// web socket server
        /// </summary>
        private WebSocketServer wsServer;
        /// <summary>
        /// delegate for print
        /// </summary>
        private UpdateMessage um;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public WSController_super(int port, UpdateMessage um) {
            this.um = um;

            wsServer = new WebSocketServer();
            wsServer.Setup(port);
            wsServer.NewSessionConnected += WsServer_NewSessionConnected;
            wsServer.NewDataReceived += WsServer_NewDataReceived;
            wsServer.NewMessageReceived += WsServer_NewMessageReceived;
            wsServer.SessionClosed += WsServer_SessionClosed;

        }
        /// <summary>
        /// over write the when there is a new user join in.
        /// </summary>
        /// <param name="session"></param>
        private void WsServer_NewSessionConnected(WebSocketSession session)
        {
            um("NewSessionConnected, ID:" + session.SessionID);
            currentsession = session;
        }
        /// <summary>
        /// over write the data received function
        /// </summary>
        /// <param name="session"></param>
        /// <param name="value"></param>
        private void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            um("NewDataReceived :" +Convert.ToBase64String(value));
        }
        /// <summary>
        /// over write the message receive function
        /// </summary>
        /// <param name="session"></param>
        /// <param name="value"></param>
        private void WsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            um("NewDataReceived :" + value);
        }
        /// <summary>
        /// update and make a tunal for output
        /// </summary>
        /// <param name="um"></param>
        public void ImplementDelegate(UpdateMessage um)
        {
            this.um = um;
        }
        /// <summary>
        /// rewrite session on close.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="value"></param>
        private void WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            um("SessionClosed, ID:" + session);

            //remove seesion from list

            currentsession = null;
        }
        /// <summary>
        /// stop the server
        /// </summary>
        public void StopServer()
        {
            wsServer.Stop();
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
        public void SendMessage(string message,WebSocketSession session) {

            if (currentsession == null)
            {
                um("No Device Connect, cannot make operate.");

            }
            else
            {
                currentsession.Send(message);
                um("Message send success.");
            }
        }
    }
}
