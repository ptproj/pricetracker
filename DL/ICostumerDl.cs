﻿using Entity;
using System.Threading.Tasks;

namespace DL
{
    public interface ICostumerDl
    {
        public Task<Costumer> post(Costumer _costumer);

        public Task<Costumer> get(string email,string password);
    }
}