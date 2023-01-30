﻿using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                if (entity.CarName.Length < 2)
                {
                    throw new BusinessRuleBrokenException("Araba adı iki karakterden az olamaz.");
                }

                if (entity.DailyPrice <= 0)
                {
                    throw new BusinessRuleBrokenException("Araba fiyatı 0 veya daha az olamaz.");
                }

                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                if (entity.CarName.Length >= 2 && entity.DailyPrice > 0)
                {
                    context.SaveChanges();
                }


            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null
                ? context.Set<Car>().ToList()
                : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
