using PowerLanguage.Common;
using System;

namespace PowerLanguage
{
	internal class TechCreateContext
	{
		public readonly StudyID StudyID;

		public readonly IntPtr Master;

		public readonly IntPtr Parent;

		public readonly int ui_thread_id;

		public TechCreateContext(StudyID _study_id, IntPtr master, IntPtr parent, int _ui_thread_id)
		{
		}

		public unsafe static IBaseStudy* BaseStudy(object _this)
		{
			return (IBaseStudy*)((TechCreateContext)_this).Master.ToPointer();
		}

		public unsafe static IBaseStudy* BaseStudy(TechCreateContext _this)
		{
			return (IBaseStudy*)_this.Master.ToPointer();
		}

		public static IntPtr ParentStudy(object _this)
		{
			return ((TechCreateContext)_this).Parent;
		}

		public static StudyID Study_ID(object _this)
		{
			return ((TechCreateContext)_this).StudyID;
		}

		public static int UIThreadID(object _this)
		{
			return ((TechCreateContext)_this).ui_thread_id;
		}
	}
}
