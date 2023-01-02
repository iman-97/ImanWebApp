﻿using ImanWebApp.DataAccess.Data;
using ImanWebApp.DataAccess.Repositiory.IRepository;

namespace ImanWebApp.DataAccess.Repositiory;

public class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext _db;

	public UnitOfWork(ApplicationDbContext db)
	{
		_db = db;
		Category = new CategoryRepository(_db);
		FoodType = new FoodTypeRepository(_db);
	}

	public ICategoryRepository Category { get; private set; }
	public IFoodTypeRepository FoodType { get; private set; }

	public void Dispose()
	{
		_db.Dispose();
	}

	public void Save()
	{
		_db.SaveChanges();
	}

}
