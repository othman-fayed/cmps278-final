using DocumentsWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace DocumentsWeb.Data.Repos
{
    public class DocumentsRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public DocumentsRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Document>> GetByOwnerAsync(string id)
        {
            return await _dbContext
                .Documents
                    .Include(d => d.Owner)
                .Where(x => x.Owner.Id == id)
                .ToListAsync();
        }

        public async Task<Document?> GetAsync(int id)
        {
            return await _dbContext
                .Documents
                    .Include(d => d.Owner)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Document>> GetAsync()
        {
            return await _dbContext
                .Documents
                    .Include(d => d.Owner)
                .ToListAsync();
        }

        public async Task DeleteAsync(Document doc)
        {
            var document = await _dbContext.Documents.FindAsync(doc.Id);
            _dbContext.Documents.Remove(document);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveAsync(Document doc)
        {
            if (doc.Id != 0)
            {
                _dbContext.Documents.Attach(doc);
            }
            else
            {
                await _dbContext.Documents.AddAsync(doc);
            }
            await _dbContext.SaveChangesAsync();
        }
    }

    public class WorkflowsRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public WorkflowsRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Workflow?> GetAsync(int id)
        {
            return await _dbContext.Workflows.FindAsync(id);
        }

        public async Task<IEnumerable<Workflow>> GetAsync()
        {
            return await _dbContext
                .Workflows
                .ToListAsync();
        }
    }
}
