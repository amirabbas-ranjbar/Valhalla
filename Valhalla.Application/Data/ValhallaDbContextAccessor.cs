﻿using Framework.Repository;
using Framework.Transactions;
using Okala.Core.Abstraction.Repositories;
using Valhalla.Domain.Partner;

namespace Valhalla.Application.Data;

public class ValhallaDbContextAccessor : UnitOfWork<ValhallaDbContext>
{
    public ValhallaDbContextAccessor(ValhallaDbContext context, IRepository<Partners> partnerRepository)
        : this(context)
    {
        PartnerRepository = partnerRepository;
    }

    public ValhallaDbContextAccessor(ValhallaDbContext context) : base(context)
    {
    }

    public readonly IRepository<Partners> PartnerRepository;
}