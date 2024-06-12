﻿using StackExchange.Redis;

namespace Multishop.Basket.Settings
{
    public class RedisService
    {
        public RedisService(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        private string host;
        private int port;
        private ConnectionMultiplexer connectionMultiplexer;

        public void Connect()
            => connectionMultiplexer = ConnectionMultiplexer.Connect($"{host}:{port}");

        public IDatabase GetDatabase()
            => connectionMultiplexer.GetDatabase(0);
    }
}