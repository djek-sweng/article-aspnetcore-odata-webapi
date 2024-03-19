namespace ODataSample.Library.Repositories;

public class ReminderRepository : IReminderRepository
{
    private readonly DatabaseContext _context;

    public ReminderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IQueryable<Reminder> Query => _context.Reminders.AsQueryable();

    public IReadOnlyList<Reminder> List => Query
        .Include(r => r.Meeting)
        .ThenInclude(m => m.Calendar)
        .ToList();
}
