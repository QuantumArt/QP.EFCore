﻿using EntityFrameworkCore.Tests.Pg.Infrastructure;
using NUnit.Framework;
using System;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData
{
    [TestFixture]
    public class UpdateFileFieldFixture : DataContextUpdateFixtureBase
    {
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_File_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            UpdateProperty<FileItemForUpdate>(access, mapping, a => a.FileValueField = $"{Guid.NewGuid()}.txt", a => a.FileValueField);
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_Date_Image_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            UpdateProperty<ImageItemForUpdate>(access, mapping, a => a.ImageValueField = $"{Guid.NewGuid()}.gif", a => a.ImageValueField);
        }
    }
}