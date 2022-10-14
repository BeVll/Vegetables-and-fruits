using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WinFormsApp21;

namespace _23_08_2022
{
    public class DbConnector
    {
        public UserContext db;

        public DbConnector()
        {
            db = new UserContext();
        }
        public List<Goods> GetGoods()
        {
            return db.Goods.ToList();
        }
        public List<Colors> GetColors()
        {
            return db.Colors.ToList();

        }
        public List<Typ> GetTypes()
        {
            return db.Typs.ToList();
        }
        public List<NewGoods> GoodsToNewGoods(List<Goods> goods)
        {
            List<NewGoods> newGoods = new List<NewGoods>();

            foreach (Goods g in goods)
            {
                NewGoods nGoods = new NewGoods();
                nGoods.Id = g.Id;
                nGoods.Name = g.Name;
                nGoods.Calories = g.Calories;
                nGoods.Colors = db.Colors.Where(d => d.Id == g.Colors).FirstOrDefault().Name;
                nGoods.Typ = db.Typs.Where(s => s.Id == g.Typ).FirstOrDefault().Name;
                newGoods.Add(nGoods);
            }

            return newGoods;
        }

        public void DeleteGoods(int id)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                Goods goods = db.Goods.Where(s => s.Id == id).FirstOrDefault();
                db.Goods.Remove(goods);
                db.SaveChanges();
                sqlTransaction.Commit();
                DeleteImages(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }

        }

        public void AddGoods(Goods goods)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Goods.Add(goods);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }

        public void UpdateGoods(Goods goods)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Goods.AddOrUpdate(goods);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }

        public void DeleteColors(Colors colors)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Colors.Attach(colors);
                db.Colors.Remove(colors);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }
        public void AddColors(Colors colors)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Colors.Add(colors);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }


        }
        public void UpdateColors(Colors colors)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Colors.AddOrUpdate(colors);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }
        public void DeleteTypes(Typ typ)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Typs.Remove(typ);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }
        public void AddTypes(Typ typ)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Typs.Add(typ);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }
        public void UpdateTypes(Typ typ)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Typs.AddOrUpdate(typ);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }

        public List<Images> GetImages()
        {
            return db.Images.ToList();
        }

        public void AddImages(Images img)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                db.Images.Add(img);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }
        public void DeleteImages(int goods_id)
        {
            System.Data.Entity.DbContextTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = db.Database.BeginTransaction();
                List<Images> imgs = db.Images.Where(s => s.Goods_id == goods_id).ToList();
                foreach (Images img in imgs)
                    db.Images.Remove(img);
                db.SaveChanges();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTransaction.Rollback();
            }
        }
    }
}
