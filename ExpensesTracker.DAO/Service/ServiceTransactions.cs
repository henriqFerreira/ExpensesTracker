﻿using ExpensesTracker.DAO.IRepository;
using ExpensesTracker.DAO.IService;
using ExpensesTracker.DAO.Models;

namespace ExpensesTracker.DAO.Service
{
    public class ServiceTransactions : IServiceTransactions
    {
        private readonly IRepositoryTransactions _transactionRepository;

        public ServiceTransactions(IRepositoryTransactions transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public bool Adicionar(Transactions entity)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Transactions ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
