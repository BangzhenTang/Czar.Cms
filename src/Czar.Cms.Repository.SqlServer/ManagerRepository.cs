/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理员接口实现                                                    
*│　作    者：yilezhu                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2018-12-18 13:28:43                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.Repository.SqlServer                                  
*│　类    名： ManagerRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Czar.Cms.Core.DbHelper;
using Czar.Cms.Core.Options;
using Czar.Cms.Core.Repository;
using Czar.Cms.IRepository;
using Czar.Cms.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Czar.Cms.Repository.SqlServer
{
    public class ManagerRepository:BaseRepository<Manager,Int32>, IManagerRepository
    {
        public ManagerRepository(IOptionsSnapshot<DbOpion> options)
        {
            _dbOpion =options.Get("CzarCms");
            if (_dbOpion == null)
            {
                throw new ArgumentNullException(nameof(DbOpion));
            }
            _dbConnection = ConnectionFactory.CreateConnection(_dbOpion.DbType, _dbOpion.ConnectionString);
        }

        public int DeleteLogical(int[] ids)
        {
            string sql = "update [Manager] set IsDelete=1 where Id in @Ids";
            return _dbConnection.Execute(sql, new
            {
                Ids = ids
            });
        }

        public async Task<int> DeleteLogicalAsync(int[] ids)
        {
            string sql = "update [Manager] set IsDelete=1 where Id in @Ids";
            return await _dbConnection.ExecuteAsync(sql, new
            {
                Ids = ids
            });
        }

    }
}