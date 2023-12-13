using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Context;

namespace TeaShopApi.DataAccessLayer.Concrete
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly TeaContext _teaContext;

		public GenericRepository(TeaContext teaContext)
		{
			_teaContext = teaContext;
		}

		public void Delete(T entity)
		{
			_teaContext.Remove(entity);
			_teaContext.SaveChanges();
		}

		public T GetByID(int id)
		{
			return _teaContext.Set<T>().Find(id);
		}

		public List<T> GetListAll()
		{
			return _teaContext.Set<T>().ToList();
		}

		public void Insert(T entity)
		{
			_teaContext.Add(entity);
			_teaContext.SaveChanges();
		}

		public void Update(T entity)
		{
			_teaContext.Update(entity);
			_teaContext.SaveChanges();
		}
	}
}
