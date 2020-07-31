﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet) {
            int _ClientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} " +
                $"connected successfully and is now player {_fromClient}");
            if (_fromClient != _ClientIdCheck) {
                Console.WriteLine($"Player \"{_username}\"(ID: {_fromClient}) has assumed the wrong ID ({_ClientIdCheck})!");
            }
        }

        public static void UDPTestReceived(int _fromClient, Packet _packet) {
            string _msg = _packet.ReadString();

            Console.WriteLine($"Received packet via UDP. Contains message: {_msg}");
        }
    }
}
