using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonDefine
{
    public const string serverURL = "http://127.0.0.1:80/";
    public struct serverPacket
    {
        public serverPacket(string packetType, string packetValue)
        {
            this.packetType = packetType;
            this.packetValue = packetValue;
        }
        public string packetType;
        public string packetValue;
    }
}