﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelDownloader.Token
{
	/// <summary>
	/// 表示文本的<see cref="NDToken"/>子类的虚拟基类。
	/// </summary>
	public abstract class NDTText : NDToken
	{
		public sealed override ICollection<NDToken> Children
		{
			get
			{
				throw new NotSupportedException();
			}

			protected set
			{
				throw new NotSupportedException();
			}
		}
		public sealed override string Title
		{
			get
			{
				throw new NotSupportedException();
			}

			set
			{
				throw new NotSupportedException();
			}
		}
		public sealed override string Description
		{
			get
			{
				throw new NotSupportedException();
			}

			set
			{
				throw new NotSupportedException();
			}
		}
		public sealed override Uri Uri
		{
			get
			{
				throw new NotSupportedException();
			}

			protected set
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// 初始化<see cref="NDTText"/>对象。
		/// </summary>
		protected NDTText() : base() { }

		/// <summary>
		/// 使用指定的统一资源标识符初始化<see cref="NDTText"/>对象。
		/// </summary>
		/// <param name="uri">指定的统一资源标识符。</param>
		protected NDTText(Uri uri) : base(uri) { }

		/// <summary>
		/// 获取和设置<see cref="NDTText"/>对象中的内容。
		/// </summary>
		public virtual string Content { get; set; }
		
		protected NDTText(string content) : this(nameof(NDTText), content) { }

		private NDTText(string type, string content) : base()
		{
			this.Content = content;
		}
	}
}
