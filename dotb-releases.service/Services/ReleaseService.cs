namespace dotb.releases;

using dotb.releases.repository;
using Grpc.Core;

public class ReleaseService : Release.ReleaseBase {
    private readonly ILogger<ReleaseService> _logger;
    private readonly ReleasesDbContext db;

    public ReleaseService(ILogger<ReleaseService> logger, ReleasesDbContext ctxt) {
        _logger = logger;
        db = ctxt;
    }

    public override Task<ServiceResponse> PerformRelease(ReleaseRequest request, ServerCallContext context) {


        db.Releases.Add(new ReleaseStore() {
            ReleaseName = request.ReleaseName,
            Version = request.Version,
            ReleaseDate = request.ReleaseDate.ToDateTime(),
        });

        return Task.FromResult(new ServiceResponse() {
            ErrorCode = 0,
            Success = true,
            Uid = "Success"
        });

    }

    public override Task<ServiceResponse> AddSystem(AddSystemRequest request, ServerCallContext context) {
        try {
            SystemsStore ss = new SystemsStore() {
                Owner = request.Owner,
                SystemsName = request.Name,
                Key = Guid.NewGuid(),
                ExternalIdentifier = request.ExternalIdentifier
            };
            db.Systems.Add(ss);
            db.SaveChanges();

            if (request.AddDefaultComponent) {
                db.Components.Add(new ComponentStore() {
                    ComponentName = request.Name,
                    SystemsStoreId = ss.Id
                });
                db.SaveChanges();
            }
            return Task.FromResult(new ServiceResponse() {
                ErrorCode = 0,
                Success = true,
                Uid = ss.Key.ToString()
            });
        } catch (Exception ex) {
            return Task.FromResult(new ServiceResponse() {
                ErrorCode = 1,
                Success = false,
            });
        }
    }
}

