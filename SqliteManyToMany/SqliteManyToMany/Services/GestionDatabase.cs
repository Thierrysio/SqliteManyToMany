using SQLite;
using SqliteManyToMany.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLiteNetExtensionsAsync.Extensions;

namespace SqliteManyToMany.Services
{
    public class GestionDatabase
    {
        #region Attributs
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        #endregion
        #region Constructeurs
        public GestionDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        #endregion
        #region Methodes
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
        });
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Salarie).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Salarie)).ConfigureAwait(false);

                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Poste).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Poste)).ConfigureAwait(false);

                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(SalariePoste).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(SalariePoste)).ConfigureAwait(false);

                }
                initialized = true;
            }
        }

        public Task<List<Salarie>> GetItemsAsync()
        {

            return Database.Table<Salarie>().ToListAsync();
        }

        public Task<List<SalariePoste>> GetItemsAsyncTodoItemEvent()
        {

            return Database.Table<SalariePoste>().ToListAsync();
        }

        public Task<Salarie> GetItemAsync(int id)
        {
            return Database.Table<Salarie>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Salarie item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsyncEvent(Poste item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Salarie item)
        {
            return Database.DeleteAsync(item);
        }
        public Task MiseAJourRelationPosteSalarie(Poste item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }
        public Task MiseAJourRelationSalariePoste(Salarie item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }

        public Task<Salarie> GetRelationSalariePoste(Salarie item)
        {
            return Database.GetWithChildrenAsync<Salarie>(item.ID);
        }

        public Task<Poste> GetRelationPosteSalarie(Poste item)
        {
            return Database.GetWithChildrenAsync<Poste>(item.ID);
        }

        #endregion
    }
}
