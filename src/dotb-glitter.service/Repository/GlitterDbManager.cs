using dotb.glitter.service;
using Microsoft.EntityFrameworkCore;
using Plisky.Glitter;

namespace Plisky.GlitterPortal;

public class GlitterDbManager {
    private GlitterDbContext db;

    public GlitterDbManager(GlitterDbContext db) {
        this.db = db;
    }

    internal void AddCommitRange(int id, ReportAuthorInfo[] commits) {
        GdbRepository r = db.Repositories.First(x => x.Id == id);
    }

    internal void AddFile(ReportRepoFile l, int id) {
        if (!db.Files.Any(x => x.Filename == l.Filename)) {
            GdbFile dbf = new GdbFile() {
                Filename = l.Filename,
            };
            db.Files.Add(dbf);
            db.SaveChanges();
            // Not right, need to work out how navigation propertys work
            db.Repositories.Include(a => a.Files).First(x => x.Id == id).Files.Add(dbf);
            db.SaveChanges();
        }
    }

    internal GdbAuthors AddOrGetAuthor(string n) {
        GdbAuthors? result = db.Authors.FirstOrDefault(x => x.EmailIdentifier == n);

        if (result == null) {
            result = new GdbAuthors() {
                EmailIdentifier = n,
                GeneralIdentifier = n,
                Scope = "global"
            };
            db.Authors.Add(result);
            db.SaveChanges();
        }
        return result;
    }

    internal GdbRepository AddRepositoryReport(ReportRepository r) {
        GdbRepository mtch = null;

        if (r.Key == null) {
            mtch = db.Repositories.FirstOrDefault(x => x.Name == r.Name);
            if (mtch == null) {
                mtch = db.Repositories.FirstOrDefault(x => x.Origin == r.OriginUri);
            }
            if (mtch == null) {
                mtch = db.Repositories.FirstOrDefault(x => x.FirstSha == r.FirstSha);
            }
            if (mtch == null) {
                r.Key = Guid.NewGuid();
            }
        }

        GdbRepository dbor = Mapper.ToDbRepository(r);
        db.Repositories.Add(dbor);

        if (string.IsNullOrEmpty(r.FirstSha)) {
            GdbRepository? repo = db.Repositories.FirstOrDefault(x => x.Name == r.Name);
            if (repo != null) {
                mtch = repo;
            }
        }
        if (mtch == null) {
            db.Add(mtch = new GdbRepository() {
                Name = r.Name
            });
            db.SaveChanges();
        }

        return PopulateRepository(mtch, r);
    }

    internal void ImportPayload(ReportPayload rpld) {
        foreach (ReportRepository r in rpld.Repositories) {
            GdbRepository gdbr = AddRepositoryReport(r);
        }
    }

    private GdbRepository PopulateRepository(GdbRepository mtch, ReportRepository r) {
        mtch.RemoteBranchCount = r.RemoteBranchCount;
        mtch.FirstSha = r.FirstSha;
        mtch.Origin = r.OriginUri;

        return mtch;
    }
}