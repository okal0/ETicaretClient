﻿namespace ETicaretClient.Contracts
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }
        public float Price { get; set; }


    }
}
