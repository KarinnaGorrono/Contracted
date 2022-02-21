using System.Collections.Generic;
using System.Data;
using System.Linq;
using Contractors.Models;
using Dapper;

namespace Contractors.Repositories
{
    public class ContractorsRepository
    {
        private readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal List<Contractor> Get()
        {
            string sql = "SELECT * FROM contractors;";
            return _db.Query<Contractor>(sql).ToList();
        }

        internal Contractor Create(Contractor newContractor)
        {
            string sql = @"
            INSERT INTO contractors
            (name, creatorId)
            VALUES
            (@Name, @CreatorId);
            SELECT LAST_INSERT_ID()
            ;";
            int id = _db.ExecuteScalar<int>(sql, newContractor);
            newContractor.Id = id;
            return newContractor;
        }
        internal void Remove(int id)
        {
            string sql = "DELETE FROM contractors WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}