﻿//-----------------------------------------------------------------------
// <copyright file="TemporaryTableTests.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Isam.Esent.Interop;
using Microsoft.Isam.Esent.Interop.Vista;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteropApiTests
{
    /// <summary>
    /// Tests for the temporary table APIs
    /// </summary>
    [TestClass]
    public class TemporaryTableTests
    {
        /// <summary>
        /// The instance being used for testing.
        /// </summary>
        private Instance instance;

        private Session session;

        /// <summary>
        /// Create the instance. Recovery is turned off for speed.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.instance = new Instance("TemporaryTableTests");
            this.instance.Parameters.Recovery = false;
            this.instance.Parameters.NoInformationEvent = true;
            this.instance.Parameters.PageTempDBMin = SystemParameters.PageTempDBSmallest;
            this.instance.Init();
            this.session = new Session(this.instance);
        }

        /// <summary>
        /// Cleanup our test instance
        /// </summary>
        [TestCleanup]
        public void Teardown()
        {
            this.instance.Term();
        }

        #region Parameter Checking tests 

        /// <summary>
        /// Null columns is invalid.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyJetOpenTempTableThrowsExceptionWhenColumnsIsNull()
        {
            JET_TABLEID tableid;
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable(this.session, null, 0, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Null columns is invalid.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyJetOpenTempTableThrowsExceptionWhenColumnidsIsNull()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            Api.JetOpenTempTable(this.session, columns, 1, TempTableGrbit.None, out tableid, null);
        }

        /// <summary>
        /// Negative column count is invalid
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyJetOpenTempTableThrowsExceptionWhenColumnCountIsNegative()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable(this.session, columns, -1, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Too-long column count is invalid
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyJetOpenTempTableThrowsExceptionWhenColumnCountIsTooLong()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable(this.session, columns, 2, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Null columns is invalid.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyJetOpenTempTable2ThrowsExceptionWhenColumnsIsNull()
        {
            JET_TABLEID tableid;
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable2(this.session, null, 0, 1033, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Null columns is invalid.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyJetOpenTempTable2ThrowsExceptionWhenColumnidsIsNull()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            Api.JetOpenTempTable2(this.session, columns, 1, 1033, TempTableGrbit.None, out tableid, null);
        }

        /// <summary>
        /// Negative column count is invalid
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyJetOpenTempTable2ThrowsExceptionWhenColumnCountIsNegative()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable2(this.session, columns, -1, 1033, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Too-long column count is invalid
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyJetOpenTempTable2ThrowsExceptionWhenColumnCountIsTooLong()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable2(this.session, columns, 2, 1033, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Null columns is invalid.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyJetOpenTempTable3ThrowsExceptionWhenColumnsIsNull()
        {
            JET_TABLEID tableid;
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable3(this.session, null, 0, null, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Null columns is invalid.
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyJetOpenTempTable3ThrowsExceptionWhenColumnidsIsNull()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            Api.JetOpenTempTable3(this.session, columns, 1, null, TempTableGrbit.None, out tableid, null);
        }

        /// <summary>
        /// Negative column count is invalid
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyJetOpenTempTable3ThrowsExceptionWhenColumnCountIsNegative()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable3(this.session, columns, -1, null, TempTableGrbit.None, out tableid, columnids);
        }

        /// <summary>
        /// Too-long column count is invalid
        /// </summary>
        [TestMethod]
        [Priority(1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyJetOpenTempTable3ThrowsExceptionWhenColumnCountIsTooLong()
        {
            JET_TABLEID tableid;
            var columns = new[] { new JET_COLUMNDEF() };
            var columnids = new JET_COLUMNID[1];
            Api.JetOpenTempTable3(this.session, columns, 2, null, TempTableGrbit.None, out tableid, columnids);
        }

        #endregion

        #region Sort data with a temporary table

        /// <summary>
        /// Sort data with a temporary table
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void SortDataWithJetOpenTempTable()
        {
            JET_TABLEID tableid;
            var columns = new[]
            {
                new JET_COLUMNDEF { coltyp = JET_coltyp.Long, grbit = ColumndefGrbit.TTKey },
                new JET_COLUMNDEF { coltyp = JET_coltyp.Text, cp = JET_CP.Unicode },
            };
            var columnids = new JET_COLUMNID[columns.Length];

            Api.JetOpenTempTable(this.session, columns, columns.Length, TempTableGrbit.None, out tableid, columnids);

            for (int i = 5; i >= 0; --i)
            {
                using (var update = new Update(this.session, tableid, JET_prep.Insert))
                {
                    Api.SetColumn(this.session, tableid, columnids[0], i);
                    Api.SetColumn(this.session, tableid, columnids[1], i.ToString(), Encoding.Unicode);
                    update.Save();
                }
            }

            var expected = new[] { "0", "1", "2", "3", "4", "5" };
            CollectionAssert.AreEqual(expected, this.RetrieveAllRecordsAsString(tableid, columnids[1]).ToArray());
            Api.JetCloseTable(this.session, tableid);
        }

        /// <summary>
        /// Sort data with a temporary table
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void SortDataWithJetOpenTempTable2()
        {
            JET_TABLEID tableid;
            var columns = new[]
            {
                new JET_COLUMNDEF { coltyp = JET_coltyp.Long, grbit = ColumndefGrbit.TTKey },
                new JET_COLUMNDEF { coltyp = JET_coltyp.Text, cp = JET_CP.Unicode },
            };
            var columnids = new JET_COLUMNID[columns.Length];

            Api.JetOpenTempTable2(this.session, columns, columns.Length, 1033, TempTableGrbit.None, out tableid, columnids);

            for (int i = 5; i >= 0; --i)
            {
                using (var update = new Update(this.session, tableid, JET_prep.Insert))
                {
                    Api.SetColumn(this.session, tableid, columnids[0], i);
                    Api.SetColumn(this.session, tableid, columnids[1], i.ToString(), Encoding.Unicode);
                    update.Save();
                }
            }

            var expected = new[] { "0", "1", "2", "3", "4", "5" };
            CollectionAssert.AreEqual(expected, this.RetrieveAllRecordsAsString(tableid, columnids[1]).ToArray());
            Api.JetCloseTable(this.session, tableid);
        }

        /// <summary>
        /// Sort data with a temporary table
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void SortDataWithJetOpenTempTable3()
        {
            JET_TABLEID tableid;
            var columns = new[]
            {
                new JET_COLUMNDEF { coltyp = JET_coltyp.Long, grbit = ColumndefGrbit.TTKey },
                new JET_COLUMNDEF { coltyp = JET_coltyp.Text, cp = JET_CP.Unicode },
            };
            var columnids = new JET_COLUMNID[columns.Length];

            Api.JetOpenTempTable3(this.session, columns, columns.Length, null, TempTableGrbit.None, out tableid, columnids);

            for (int i = 5; i >= 0; --i)
            {
                using (var update = new Update(this.session, tableid, JET_prep.Insert))
                {
                    Api.SetColumn(this.session, tableid, columnids[0], i);
                    Api.SetColumn(this.session, tableid, columnids[1], i.ToString(), Encoding.Unicode);
                    update.Save();
                }
            }

            var expected = new[] { "0", "1", "2", "3", "4", "5" };
            CollectionAssert.AreEqual(expected, this.RetrieveAllRecordsAsString(tableid, columnids[1]).ToArray());
            Api.JetCloseTable(this.session, tableid);
        }

        /// <summary>
        /// Sort data with a temporary table
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void SortDataCaseSensitiveWithJetOpenTempTable3()
        {
            JET_TABLEID tableid;
            var columns = new[]
            {
                new JET_COLUMNDEF { coltyp = JET_coltyp.Text, cp = JET_CP.Unicode, grbit = ColumndefGrbit.TTKey },
            };
            var columnids = new JET_COLUMNID[columns.Length];

            var idxunicode = new JET_UNICODEINDEX
            {
                dwMapFlags = Conversions.LCMapFlagsFromCompareOptions(CompareOptions.None),
                lcid = 1033,
            };
            Api.JetOpenTempTable3(this.session, columns, columns.Length, idxunicode, TempTableGrbit.None, out tableid, columnids);

            var data = new[] { "g", "a", "A", "aa", "x", "b", "X" };
            foreach (string s in data)
            {
                using (var update = new Update(this.session, tableid, JET_prep.Insert))
                {
                    Api.SetColumn(this.session, tableid, columnids[0], s, Encoding.Unicode);
                    update.Save();
                }
            }

            Array.Sort(data);
            CollectionAssert.AreEqual(data, this.RetrieveAllRecordsAsString(tableid, columnids[0]).ToArray());
            Api.JetCloseTable(this.session, tableid);
        }

        /// <summary>
        /// Sort data with a temporary table
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void SortLongValueDataWithJetOpenTempTable3()
        {
            JET_TABLEID tableid;
            var columns = new[]
            {
                new JET_COLUMNDEF { coltyp = JET_coltyp.LongText, cp = JET_CP.Unicode, grbit = ColumndefGrbit.TTKey },
            };
            var columnids = new JET_COLUMNID[columns.Length];

            var idxunicode = new JET_UNICODEINDEX
            {
                dwMapFlags = Conversions.LCMapFlagsFromCompareOptions(CompareOptions.None),
                lcid = 1033,
            };
            Api.JetOpenTempTable3(this.session, columns, columns.Length, idxunicode, TempTableGrbit.None, out tableid, columnids);

            var data = new[]
            {
                Any.StringOfLength(1999),
                Any.StringOfLength(2000),
                Any.StringOfLength(1999),
                Any.StringOfLength(2000),
                Any.StringOfLength(2001),
                Any.StringOfLength(2000),
                Any.StringOfLength(1999),
            };

            using (var transaction = new Transaction(this.session))
            {
                foreach (string s in data)
                {
                    using (var update = new Update(this.session, tableid, JET_prep.Insert))
                    {
                        Api.SetColumn(this.session, tableid, columnids[0], s, Encoding.Unicode);
                        update.Save();
                    }
                }

                transaction.Commit(CommitTransactionGrbit.None);
            }

            Array.Sort(data);
            CollectionAssert.AreEqual(data, this.RetrieveAllRecordsAsString(tableid, columnids[0]).ToArray());
            Api.JetCloseTable(this.session, tableid);
        }

        /// <summary>
        /// Sort data with a temporary table
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void SortDataCaseSensitiveWithJetOpenTemporaryTable()
        {
            if (!EsentVersion.SupportsVistaFeatures)
            {
                return;
            }

            var columns = new[]
            {
                new JET_COLUMNDEF { coltyp = JET_coltyp.Text, cp = JET_CP.Unicode, grbit = ColumndefGrbit.TTKey },
            };
            var columnids = new JET_COLUMNID[columns.Length];

            var idxunicode = new JET_UNICODEINDEX
            {
                dwMapFlags = Conversions.LCMapFlagsFromCompareOptions(CompareOptions.None),
                lcid = 1033,
            };

            var opentemporarytable = new JET_OPENTEMPORARYTABLE
            {
                cbKeyMost = SystemParameters.KeyMost,
                ccolumn = columns.Length,
                grbit = TempTableGrbit.None,
                pidxunicode = idxunicode,
                prgcolumndef = columns,
                prgcolumnid = columnids,
            };
            VistaApi.JetOpenTemporaryTable(this.session, opentemporarytable);

            var data = new[] { "g", "a", "A", "aa", "x", "b", "X" };
            foreach (string s in data)
            {
                using (var update = new Update(this.session, opentemporarytable.tableid, JET_prep.Insert))
                {
                    Api.SetColumn(this.session, opentemporarytable.tableid, columnids[0], s, Encoding.Unicode);
                    update.Save();
                }
            }

            Array.Sort(data);
            CollectionAssert.AreEqual(
                data, this.RetrieveAllRecordsAsString(opentemporarytable.tableid, columnids[0]).ToArray());
            Api.JetCloseTable(this.session, opentemporarytable.tableid);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Enumerate all records and retrieve the specified column as a string.
        /// </summary>
        /// <param name="tableid">The table to enumerate.</param>
        /// <param name="columnid">The column to retrieve.</param>
        /// <returns>An enumeration of the column in all the records.</returns>
        private IEnumerable<string> RetrieveAllRecordsAsString(JET_TABLEID tableid, JET_COLUMNID columnid)
        {
            Api.MoveBeforeFirst(this.session, tableid);
            while (Api.TryMoveNext(this.session, tableid))
            {
                yield return Api.RetrieveColumnAsString(this.session, tableid, columnid);
            }
        }

        #endregion
    }
}
