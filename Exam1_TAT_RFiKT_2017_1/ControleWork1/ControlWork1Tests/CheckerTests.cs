using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task_01;

namespace task_01Tests
{
    [TestClass]
    public class CheckerTests
    {
        [TestMethod]
        public void TestCheckRightFullPath ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"c:\Directory\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckSingleDiskNamePath ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"c:\Directory\admin\text.txt" ) );
        }

        public void TestCheckRelativePathWithDiscNameFromDirectoryBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"C:..\tmp.txt\admin\text.txt" ) );
        }

        public void TestCheckRelativePathWithDiscNameFromCurrentBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"C:.\tmp.txt\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckPathFromCurrentFolderWithDiscName ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"c:Users\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckPathFromCurrentFolderWithoutDiscName ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"Users\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckRelativePathFromCurrentDirectory ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @".\users\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckRelativePathFromDirectoryBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"..\users\text" ) );
        }

        [TestMethod]
        public void TestCheckRelativePathFromDirectoriesBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"..\..\..\\users\text" ) );
        }

        [TestMethod]
        public void TestCheckDirectoryNameOnly ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"users" ) );
        }

        [TestMethod]
        public void TestCheckAllowedNameThatContainsForbiddenStartString ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"c: _vti_cnf\Folder" ) );
        }

        [TestMethod]
        public void TestCheckAllowedNameThatContainsForbiddenName ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"c: com1\Folder" ) );
        }

        [TestMethod]
        public void TestCheckVeryLongRightFullPath ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\c:\\Directory\admin\text.txt" ) );
        }

        public void TestCheckVeryLongRelativePathWithDiscNameFromDirectoryBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\C:..\tmp.txt\admin\text.txt" ) );
        }

        public void TestCheckVeryLongRelativePathWithDiscNameFromCurrentBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\C:.\tmp.txt\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckVeryLongPathFromCurrentFolderWithDiscName ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\c:Users\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckFromCurrentFolderWithoutDiscName ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\Users\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckVeryLongRelativePathFromCurrentDirectory ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\.\users\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckVeryLongRelativePathFromDirectoryBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\..\users\text" ) );
        }

        [TestMethod]
        public void TestCheckVeryLongRelativePathFromDirectoriesBelow ()
        {
            Assert.AreEqual ( true , new Checker ().Check ( @"\\?\..\..\..\users\text" ) );
        }

        [TestMethod]
        public void TestCheckPathWithWrongLongDiskName ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"fourc:\Directory\admin\text.txt" ) );
        }

        [TestMethod]
        public void TestCheckPathWithSpaceAfterColonBeforeBackslash ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c: \\Users" ) );
        }

        [TestMethod]
        public void TestCheckPathWithSpaceAfterDiscNameBeforeColon ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c :\Users" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolVerticalLine ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"users|" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolStar ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:\\*users" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolSemicolon ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:\\use;rs" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolSlash ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:\\use/rs\pragram data\txt" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolSquareBrace ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:\\us[ers" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolstarBackSquareBrace ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:\\use]rs" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolstarFigureBrace ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:\\use{rs" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenSymbolstarBackFigureBrace ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:\\use}rs" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenStartName_vti_cnf ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"_vti_cnftestname.txt\Folder" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenStartName_vti_cnfAfterDiscName ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:_vti_cnftestname.txt\Folder" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenFileAndDirectoryNameCom1 ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"com1\testname.txt\Folder" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenFileAndDirectoryNameAUX ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"AUX\testname.txt\Folder" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenFileAndDirectoryNameLPT1 ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"LPT1\testname.txt\Folder" ) );
        }

        [TestMethod]
        public void TestCheckForbiddenFileAndDirectoryNameLPT2 ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"LPT2\testname.txt\Folder" ) );
        }

        [TestMethod]
        public void TestCheckPointOnTheEndOfFileWithoutSpacesOnTheEnd ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:temp." ) );
        }

        [TestMethod]
        public void TestCheckPointOnTheEndOfFileWithSpacesOnTheEnd ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:temp.    " ) );
        }

        [TestMethod]
        public void TestCheckPointOnTheEndOfDirectoryWithSpacesOnTheEnd ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:..\tempone  \two. \\Program" ) );
        }

        [TestMethod]
        public void TestCheckPointOnTheEndOfDirectoryWithoutSpacesOnTheEnd ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:.\temp\two\three\." ) );
        }

        [TestMethod]
        public void TestCheckNameOfDirectoryIsSpace ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:..\temp\ \folder" ) );
        }

        [TestMethod]
        public void TestCheckNameOfDirectoryIsSpaceAfterPoint ()
        {
            Assert.AreEqual ( false , new Checker ().Check ( @"c:..\temp\.. \folder" ) );
        }

    }
}
