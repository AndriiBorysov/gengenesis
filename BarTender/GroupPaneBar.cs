using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BarTender
{
	/// <summary>
	/// Core class of the component.
	/// It holds several <see cref="GroupPane"/>s, manages their positioning
	/// and holds all visual properties for unifying the look of all contained groups.
	/// </summary>
	public class GroupPaneBar : ScrollableControl, ISupportInitialize
	{
		#region Events

		/// <summary>
		/// Event which gets fired when <see cref="TextAlign"/> has changed.
		/// </summary>
		public event EventHandler TextAlignChanged;

		/// <summary>
		/// Event which gets fired when <see cref="ButtonArrowColor"/> has changed.
		/// </summary>
		public event EventHandler ButtonArrowColorChanged;

		/// <summary>
		/// Event which gets fired when <see cref="ButtonHighlightAlpha"/> has changed.
		/// </summary>
		public event EventHandler ButtonHighlightAlphaChanged;

		/// <summary>
		/// Event which gets fired when <see cref="ButtonHighlightColor"/> has changed.
		/// </summary>
		public event EventHandler ButtonHighlightColorChanged;

		/// <summary>
		/// Event which gets fired when <see cref="HeaderColor1"/> has changed.
		/// </summary>
		public event EventHandler HeaderColor1Changed;

		/// <summary>
		/// Event which gets fired when <see cref="HeaderColor2"/> has changed.
		/// </summary>
		public event EventHandler HeaderColor2Changed;

		/// <summary>
		/// Event which gets fired when <see cref="BorderColor"/> has changed.
		/// </summary>
		public event EventHandler BorderColorChanged;

		/// <summary>
		/// Event which gets fired when <see cref="HeaderGradientMode"/> has changed.
		/// </summary>
		public event EventHandler HeaderGradientModeChanged;

		/// <summary>
		/// Event which gets fired when <see cref="HeaderHeight"/> has changed.
		/// </summary>
		public event EventHandler HeaderHeightChanged;

		/// <summary>
		/// Event which gets fired when <see cref="BorderWidth"/> has changed.
		/// </summary>
		public event EventHandler BorderWidthChanged;

		/// <summary>
		/// Event which gets fired when <see cref="CanResize"/> has changed.
		/// </summary>
		public event EventHandler CanResizeChanged;

		/// <summary>
		/// Event which gets fired when <see cref="CanExpandCollapse"/> has changed.
		/// </summary>
		public event EventHandler CanExpandCollapseChanged;

		/// <summary>
		/// Event which gets fired when <see cref="ShowExpandCollapseButton"/> has changed.
		/// </summary>
		public event EventHandler ShowExpandCollapseButtonChanged;

		/// <summary>
		/// Event which gets fired when <see cref="ImagesEnabled"/> has changed.
		/// </summary>
		public event EventHandler ImagesEnabledChanged;

		/// <summary>
		/// Event which gets fired when <see cref="AnimationEnabled"/> has changed.
		/// </summary>
		public event EventHandler AnimationEnabledChanged;

		/// <summary>
		/// Event which gets fired when <see cref="AnimationIntervall"/> has changed.
		/// </summary>
		public event EventHandler AnimationIntervallChanged;

		/// <summary>
		/// Event which gets fired when <see cref="AnimationStepSize"/> has changed.
		/// </summary>
		public event EventHandler AnimationStepSizeChanged;

		/// <summary>
		/// Event which gets fired when <see cref="MinimumExpandedHeight"/> has changed.
		/// </summary>
		public event EventHandler MinimumExpandedHeightChanged;

		/// <summary>
		/// Event which gets fired when <see cref="BorderStyle"/> has changed.
		/// </summary>
		public event EventHandler BorderStyleChanged;

		/// <summary>
		/// Event which gets fired when a <see cref="GroupPane"/> has been added.
		/// </summary>
		public event GroupPaneEventHandler GroupPaneAdded;

		/// <summary>
		/// Event which gets fired when a <see cref="GroupPane"/> has been removed.
		/// </summary>
		public event GroupPaneEventHandler GroupPaneRemoved;

		/// <summary>
		/// Event which gets fired before a <see cref="GroupPane"/> is collapsed.
		/// </summary>
		public event GroupPaneCancelEventHandler GroupPaneCollapsing;

		/// <summary>
		/// Event which gets fired after a <see cref="GroupPane"/> has collapsed.
		/// </summary>
		public event GroupPaneEventHandler GroupPaneCollapsed;

		/// <summary>
		/// Event which gets fired before a <see cref="GroupPane"/> is expanded.
		/// </summary>
		public event GroupPaneCancelEventHandler GroupPaneExpanding;

		/// <summary>
		/// Event which gets fired after a <see cref="GroupPane"/> has expanded.
		/// </summary>
		public event GroupPaneEventHandler GroupPaneExpanded;

		#endregion

		#region Fields

		private const int DEFAULT_BORDER_WIDTH = 1;
		private const int DEFAULT_HEADER_HEIGHT = 24;
		private const byte DEFAULT_BUTTON_HIGHLIGHT_ALPHA = 70;
		private const LinearGradientMode DEFAULT_HEADER_LINEAR_GRADIENT_MODE = LinearGradientMode.Vertical;
		private const bool DEFAULT_CAN_RESIZE = true;
		private const bool DEFAULT_CAN_EXPAND_COLLAPSE = true;
		private const bool DEFAULT_SHOW_EXPAND_COLLAPSE_BUTTON = true;
		private const bool DEFAULT_IMAGES_ENABLED = true;
		private const bool DEFAULT_ANIMATION_ENABLED = true;        
		private const int DEFAULT_ANIMATION_INTERVALL = 10;
		private const double DEFAULT_ANIMATION_STEPSIZE = 5;
		private const ContentAlignment DEFAULT_TEXT_ALIGNMENT = ContentAlignment.MiddleCenter;

		private int _borderWidth = DEFAULT_BORDER_WIDTH;
		private int _headerHeight = DEFAULT_HEADER_HEIGHT;
		private Color _headerColor1;
		private Color _headerColor2;
		private Color _borderColor;
		private Color _buttonHighlightColor;
		private Color _buttonArrowColor;
		private byte _buttonHighlightAlpha = DEFAULT_BUTTON_HIGHLIGHT_ALPHA;
		private LinearGradientMode _headerGradientMode = DEFAULT_HEADER_LINEAR_GRADIENT_MODE;
		private bool _canResize = DEFAULT_CAN_RESIZE;
		private bool _canExpandCollapse = DEFAULT_CAN_EXPAND_COLLAPSE;        
		private bool _showExpandCollapseButton = DEFAULT_SHOW_EXPAND_COLLAPSE_BUTTON;
		private bool _imagesEnabled = DEFAULT_ANIMATION_ENABLED;
		private bool _animationEnabled = DEFAULT_IMAGES_ENABLED;
		private int _animatorIntervall = DEFAULT_ANIMATION_INTERVALL;
		private double _animatorStepSize = DEFAULT_ANIMATION_STEPSIZE;
		private int _minimumExpandedHeight = -1;

      
		private StringFormat _stringFormat;
		private ContentAlignment _textAlign = DEFAULT_TEXT_ALIGNMENT;

		private BorderStyle _borderStyle = BorderStyle.FixedSingle;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new empty instance.
		/// </summary>
		public GroupPaneBar()
		{
			base.DockPadding.All = 1;

			_headerColor1 = DefaultHeaderColor1;
			_headerColor2 = DefaultHeaderColor2;
			_borderColor = DefaultBorderColor;
			_buttonHighlightColor = DefaultButtonHighlightColor;
			_buttonArrowColor = DefaultButtonArrowColor;

			this.AutoScroll = true;
			AutoCorrectMinimumExpandedHeight();
		}

		#endregion

		#region Public interface

		#region Create/Add/Remove/Get GroupPanes

		/// <summary>
		/// Adds a new <see cref="GroupPane"/> to the end of the list.
		/// </summary>
		/// <param name="control">Element which should initially beend placed in the new group.</param>
		/// <param name="text">Initial text of the new group.</param>
		/// <param name="image">Initial image of the new group.</param>
		/// <returns>The newly created <see cref="GroupPane"/>.</returns>
		public GroupPane Add(Control control, string text, Image image)
		{
			return Add(control, text, image, false);
		}

		/// <summary>
		/// Adds a new <see cref="GroupPane"/> to the end of the list.
		/// </summary>
		/// <param name="control">Element which should initially beend placed in the new group.</param>
		/// <param name="text">Initial text of the new group.</param>
		/// <param name="image">Initial image of the new group.</param>
		/// <param name="adjustGroupPaneHeightToControlheight">Sets whether the expanded height of 
		/// the resulting group pane should match the height of the given control.</param>
		/// <returns>The newly created <see cref="GroupPane"/>.</returns>
		public GroupPane Add(Control control, string text, Image image, bool adjustGroupPaneHeightToControlheight)
		{
			int controlHeight = control == null ? 0 : control.Height;

			GroupPane result = CreateGroupPane(control, text, image);
			if (adjustGroupPaneHeightToControlheight)
				result.ExpandedHeight = controlHeight + result.DockPadding.Top + result.DockPadding.Bottom;
			Add(result);
			return result;
		}

		/// <summary>
		/// Adds a <see cref="GroupPane"/> to the end of the list.		
		/// </summary>
		/// <param name="groupPane">Group to be added.</param>
		public void Add(GroupPane groupPane)
		{
			this.InsertAt(Controls.Count, groupPane);

			groupPane.PaneCollapsing += new CancelEventHandler(OnGroupPaneCollapsing);
			groupPane.PaneCollapsed += new EventHandler(OnGroupPaneCollapsed);
			groupPane.PaneExpanding += new CancelEventHandler(OnGroupPaneExpanding);
			groupPane.PaneExpanded += new EventHandler(OnGroupPaneExpanded);
		}

		/// <summary>
		/// Removes a <see cref="GroupPane"/> from the list.
		/// </summary>
		/// <param name="groupPane">Group to be removed.</param>
		public void Remove(GroupPane groupPane)
		{
			this.Controls.Remove(groupPane);

			groupPane.PaneCollapsing -= new CancelEventHandler(OnGroupPaneCollapsing);
			groupPane.PaneCollapsed -= new EventHandler(OnGroupPaneCollapsed);
			groupPane.PaneExpanding -= new CancelEventHandler(OnGroupPaneExpanding);
			groupPane.PaneExpanded -= new EventHandler(OnGroupPaneExpanded);

			OnGroupPaneRemoved(new GroupPaneEventArgs(groupPane));
		}

		/// <summary>
		/// Removes the <see cref="GroupPane"/> at the specified index. 
		/// </summary>
		/// <param name="index">Index of the group to be removed.</param>
		public void RemoveAt(int index)
		{
			this.Remove(this[index]);
		}

		/// <summary>
		/// Number of contained groups.
		/// </summary>
		[Browsable(false)]
		public int Count 
		{
			get { return this.Controls.Count; }
		}

		/// <summary>
		/// Gets the group at the specified position.
		/// </summary>
		public GroupPane this[int index] 
		{
			get { return (GroupPane)this.Controls[Controls.Count - index - 1]; }
		}

		/// <summary>
		/// Removes all groups.
		/// </summary>
		public void Clear()
		{
			while (this.Controls.Count > 0)
				RemoveAt(0);
		}

		/// <summary>
		/// Inserts a <see cref="GroupPane"/> at a specified position.		
		/// </summary>
		/// <param name="index">Insertion index.</param>
		/// <param name="groupPane">Group to be added.</param>
		public void InsertAt(int index, GroupPane groupPane)
		{
			if (groupPane.Parent != null)
				throw new ArgumentException("GroupPane already belongs to another container.", "groupPane");

			if (groupPane.ParentBar != this)
				throw new ArgumentException("GroupPane was not created by this instance.", "groupPane");

			index = Controls.Count - index;
			groupPane.Dock = DockStyle.Top;
			Controls.Add(groupPane);
			Controls.SetChildIndex(groupPane, index);

			OnGroupPaneAdded(new GroupPaneEventArgs(groupPane));
		}

		/// <summary>
		/// Creates a new empty <see cref="GroupPane"/> which is valid for being added
		/// to this instance.
		/// </summary>
		/// <returns>Newly created <see cref="GroupPane"/>.</returns>
		public GroupPane CreateGroupPane()
		{
			return CreateGroupPane(null, "", null);
		}

		/// <summary>
		/// Creates a new <see cref="GroupPane"/> which is valid for being added
		/// to this instance.
		/// </summary>
		/// <param name="control">Element which should initially beend placed in the new group.</param>
		/// <param name="text">Initial text of the new group.</param>
		/// <param name="image">Initial image of the new group.</param>
		/// <returns>Newly created <see cref="GroupPane"/>.</returns>
		public GroupPane CreateGroupPane(Control control, string text, Image image)
		{
			GroupPane result = new GroupPane(this);

			result.Control = control;
			result.Text = text;
			result.Image = image;

			return result;
		}

		#endregion

		#region Visual properties
		
		/// <summary>
		/// Gets or sets the type of border of the whole control.
		/// </summary>
		[DefaultValue(BorderStyle.FixedSingle), System.Runtime.InteropServices.DispId(-504)]
		[Category("Appearance")]
		[Description("The type of border of the whole control.")]
		public BorderStyle BorderStyle
		{
			get { return _borderStyle; }
			set
			{
				if (_borderStyle != value)
				{
					if (!Enum.IsDefined(typeof(BorderStyle), value))
						throw new InvalidEnumArgumentException("value", (int) value, typeof(BorderStyle));

					_borderStyle = value;
					base.UpdateStyles();

					OnBorderStyleChanged(EventArgs.Empty);
				}
			}
		}       

		/// <summary>
		/// Gets/sets the color of the arrow on the expand/collapse button.
		/// </summary>
		[Category("Appearance")]
		[Description("The color of the arrow on the expand/collapse button.")]
		public Color ButtonArrowColor 
		{
			get { return _buttonArrowColor; }
			set
			{
				if (_buttonArrowColor == value)
					return;

				_buttonArrowColor = value;
				OnButtonArrowColorChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets the alpha value of the color of the color highlighting of the expand/collapse button.
		/// </summary>
		[Category("Appearance")]
		[Description("The alpha value of the color of the color highlighting of the expand/collapse button.")]
		[DefaultValue(DEFAULT_BUTTON_HIGHLIGHT_ALPHA)]
		public byte ButtonHighlightAlpha 
		{
			get { return _buttonHighlightAlpha; }
			set
			{
				if (_buttonHighlightAlpha == value)
					return;

				_buttonHighlightAlpha = value;
				OnButtonHighlightAlphaChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets the color of the highlighting of the expand/collapse button.
		/// </summary>
		[Category("Appearance")]
		[Description("The color of the highlighting of the expand/collapse button.")]
		public Color ButtonHighlightColor 
		{
			get { return _buttonHighlightColor; }
			set
			{
				if (_buttonHighlightColor == value)
					return;

				_buttonHighlightColor = value;
				OnButtonHighlightColorChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets the first color of the background of the header.
		/// </summary>
		[Category("Appearance")]
		[Description("The first color of the background of the header.")]
		public Color HeaderColor1 
		{
			get { return _headerColor1; }
			set
			{
				if (_headerColor1 == value)
					return;

				_headerColor1 = value;
				OnHeaderColor1Changed(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets the second color of the background of the header.
		/// </summary>
		[Category("Appearance")]
		[Description("The second color of the background of the header.")]
		public Color HeaderColor2 
		{
			get { return _headerColor2; }
			set
			{
				if (_headerColor2 == value)
					return;

				_headerColor2 = value;
				OnHeaderColor2Changed(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets the color of the borders.
		/// </summary>
		[Category("Appearance")]
		[Description("The color of the borders.")]
		public Color BorderColor 
		{
			get { return _borderColor; }
			set
			{
				if (_borderColor == value)
					return;

				_borderColor = value;
				OnBorderColorChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets how the gradient between the two header colors is painted.
		/// </summary>
		[Category("Appearance")]
		[Description("Defines how the gradient between the two header colors is painted.")]
		[DefaultValue(DEFAULT_HEADER_LINEAR_GRADIENT_MODE)]
		public LinearGradientMode HeaderGradientMode 
		{
			get { return _headerGradientMode; }
			set
			{
				if (_headerGradientMode == value)
					return;

				_headerGradientMode = value;
				OnHeaderGradientModeChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets the height of the header.
		/// </summary>
		[Category("Appearance")]
		[Description("The height of the header.")]
		[DefaultValue(DEFAULT_HEADER_HEIGHT)]
		public int HeaderHeight 
		{
			get { return _headerHeight; }
			set
			{
				if (_headerHeight == value)
					return;

				_headerHeight = value;
				OnHeaderHeightChanged(EventArgs.Empty);
				AdjustDockPadding();
				AutoCorrectMinimumExpandedHeight();
			}
		}

		/// <summary>
		/// Gets/sets the width of the borders.
		/// </summary>
		[Category("Appearance")]
		[Description("The width of the borders.")]
		[DefaultValue(DEFAULT_BORDER_WIDTH)]
		public int BorderWidth 
		{
			get { return _borderWidth; }
			set
			{
				if (_borderWidth < 1 || _borderWidth > 10)
					throw new ArgumentException("Value must be between 1 and 10.", "BorderWidth");

				if (_borderWidth == value)
					return;

				_borderWidth = value;
				OnBorderWidthChanged(EventArgs.Empty);
				AdjustDockPadding();
				AutoCorrectMinimumExpandedHeight();
			}
		}

		/// <summary>
		/// Gets/sets whether users can resize groups or not.
		/// </summary>
		[Category("Behavior")]
		[Description("Defines whether users can resize groups or not.")]
		[DefaultValue(DEFAULT_CAN_RESIZE)]
		public bool CanResize 
		{
			get { return _canResize; }
			set
			{
				if (_canResize == value)
					return;

				_canResize = value;
				OnCanResizeChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets/sets whether user can collpase/expand groups or not.
		/// </summary>
		[Category("Behavior")]
		[Description("Defines whether users can collpase/expand groups or not.")]
		[DefaultValue(DEFAULT_CAN_EXPAND_COLLAPSE)]
		public bool CanExpandCollapse 
		{
			get { return _canExpandCollapse; }
			set
			{
				if (_canExpandCollapse == value)
					return;

				_canExpandCollapse = value;
				OnCanExpandCollapseChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets whether the collpase/expand button should be shown or not.
		/// If this property is set to false but <see cref="CanExpandCollapse"/>
		/// is set to true than the user can expand/collapse the group by
		/// simply clicking into the header.
		/// </summary>
		[Category("Behavior")]
		[Description("Defines whether the collpase/expand button should be shown or not.")]
		[DefaultValue(DEFAULT_SHOW_EXPAND_COLLAPSE_BUTTON)]
		public bool ShowExpandCollapseButton 
		{
			get { return _showExpandCollapseButton; }
			set
			{
				if (_showExpandCollapseButton == value)
					return;

				_showExpandCollapseButton = value;
				OnShowExpandCollapseButtonChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets whether images are drawn or not.
		/// </summary>
		[Category("Appearance")]
		[Description("Defines whether images are drawn or not.")]
		[DefaultValue(DEFAULT_IMAGES_ENABLED)]
		public bool ImagesEnabled 
		{
			get { return _imagesEnabled; }
			set
			{
				if (_imagesEnabled == value)
					return;

				_imagesEnabled = value;
				OnImagesEnabledChanged(EventArgs.Empty);
				Invalidate(true);
			}
		}

		/// <summary>
		/// Gets/sets whether expand/collapse animation is enabled or not.
		/// </summary>
		[Category("Appearance")]
		[Description("Defines whether expand/collapse animation is enabled or not.")]
		[DefaultValue(DEFAULT_ANIMATION_ENABLED)]
		public bool AnimationEnabled 
		{
			get { return _animationEnabled; }
			set
			{
				if (_animationEnabled == value)
					return;

				_animationEnabled = value;
				OnAnimationEnabledChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets/sets the update intervall of expand/collapse animations.
		/// </summary>
		[Category("Appearance")]
		[Description("The update intervall of expand/collapse animations.")]
		[DefaultValue(DEFAULT_ANIMATION_INTERVALL)]
		public int AnimationIntervall 
		{
			get { return _animatorIntervall; }
			set
			{
				if (_animatorIntervall == value)
					return;

				_animatorIntervall = value;
				OnAnimationIntervallChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets/sets the step size of expand/collapse animations.
		/// </summary>
		[Category("Appearance")]
		[Description("The step size of expand/collapse animations.")]
		[DefaultValue(DEFAULT_ANIMATION_STEPSIZE)]
		public double AnimationStepSize 
		{
			get { return _animatorStepSize; }
			set
			{
				if (_animatorStepSize == value)
					return;

				_animatorStepSize = value;
				OnAnimationStepSizeChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets or sets the alignment of the text.
		/// </summary>
		[Description("The alignment of the text.")]
		[DefaultValue(DEFAULT_TEXT_ALIGNMENT), Category("Appearance")]
		public ContentAlignment TextAlign 
		{
			get { return _textAlign; }
			set 
			{
				if (_textAlign == value)
					return;

				_textAlign = value;
				ClearStringFormat();
				Invalidate(true);
				OnTextAlignChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets or sets the minimum height the groups should have
		/// when they are expanded.
		/// Thus the user won't be able to resize it to less than this given value.
		/// </summary>
		[Description("The minimum height the groups should have when they are expanded.")]
		[DefaultValue(DEFAULT_TEXT_ALIGNMENT), Category("Appearance")]
		public int MinimumExpandedHeight
		{
			get { return _minimumExpandedHeight; }
			set 
			{
				if (value < MinimumExpandedHeightInternal)
					throw new ArgumentException("Value must not be smaller than " + MinimumExpandedHeightInternal, "MinimumExpandedHeight");

				if (_minimumExpandedHeight == value)
					return;

				_minimumExpandedHeight = value;

				foreach (GroupPane groupPane in this.Controls)
				{
					if (groupPane.ExpandedHeight < _minimumExpandedHeight)
						groupPane.ExpandedHeight = _minimumExpandedHeight;
					if (!groupPane.Expanded)
						groupPane.Height = CollapsedHeight;
				}

				OnMinimumExpandedHeightChanged(EventArgs.Empty);
			}
		}

		#endregion

		#region Collapse/Expand

		/// <summary>
		/// Gets whether there is currently and expand/collapse animation running.
		/// </summary>
		[Browsable(false)]
		public bool IsAnimationRunning
		{
			get 
			{
				foreach (GroupPane groupPane in this.Controls)
					if (groupPane.IsAnimationRunning)
						return true;

				return false;
			}
		}

		/// <summary>
		/// Collapses all contained groups immediatly.
		/// </summary>
		public void CollapseAll()
		{
			CollapseAll(false);
		}

		/// <summary>
		/// Collapses all contained groups.
		/// </summary>
		/// <param name="animate">Indicates whether the collapse should be animated.</param>
		public void CollapseAll(bool animate)
		{
			foreach (GroupPane groupPane in this.Controls)
				groupPane.Collapse(animate);
		}

		/// <summary>
		/// Expands all contained groups immediatly.
		/// </summary>
		public void ExpandAll()
		{
			ExpandAll(false);
		}

		/// <summary>
		/// Expands all contained groups.
		/// </summary>
		/// <param name="animate">Indicates whether the expand should be animated.</param>
		public void ExpandAll(bool animate)
		{
			foreach (GroupPane groupPane in this.Controls)
				groupPane.Expand(animate);
		}

		#endregion

		#endregion

		#region Internal interface
		
		internal StringFormat GetStringFormat()
		{
			if (_stringFormat == null)
				_stringFormat = CreateStringFormat();
			return _stringFormat;
		}

		internal int MinimumExpandedHeightInternal
		{
			get { return _headerHeight + 6 * _borderWidth; }
		}

		internal int CollapsedHeight 
		{
			get { return _headerHeight + 3 * _borderWidth; }
		}

		#endregion

		#region Protected interface

		#region Defaults

		/// <summary>
		/// Gets the default value of the <see cref="HeaderColor1"/> property.
		/// </summary>
		protected virtual Color DefaultHeaderColor1
		{
			get { return Color.BurlyWood; }
		}

		/// <summary>
		/// Gets the default value of the <see cref="HeaderColor2"/> property.
		/// </summary>
		protected virtual Color DefaultHeaderColor2
		{
			get { return Color.OldLace; }
		}

		/// <summary>
		/// Gets the default value of the <see cref="BorderColor"/> property.
		/// </summary>
		protected virtual Color DefaultBorderColor
		{
			get { return Color.Black; }
		}

		/// <summary>
		/// Gets the default value of the <see cref="ButtonHighlightColor"/> property.
		/// </summary>
		protected virtual Color DefaultButtonHighlightColor
		{
			get { return Color.Red; }
		}

		/// <summary>
		/// Gets the default value of the <see cref="ButtonArrowColor"/> property.
		/// </summary>
		protected virtual Color DefaultButtonArrowColor
		{
			get { return Color.Black; }
		}

		#endregion

		#region ShouldSerialize

		/// <summary>
		/// Indicates the designer whether <see cref="ButtonArrowColor"/> needs
		/// to be serialized.
		/// </summary>
		protected virtual bool ShouldSerializeButtonArrowColor()
		{
			return !_buttonArrowColor.Equals(DefaultButtonArrowColor);
		}

		/// <summary>
		/// Indicates the designer whether <see cref="ButtonHighlightColor"/> needs
		/// to be serialized.
		/// </summary>
		protected virtual bool ShouldSerializeButtonHighlightColor()
		{
			return !_buttonHighlightColor.Equals(DefaultButtonHighlightColor);
		}

		/// <summary>
		/// Indicates the designer whether <see cref="HeaderColor1"/> needs
		/// to be serialized.
		/// </summary>
		protected virtual bool ShouldSerializeHeaderColor1()
		{
			return !_headerColor1.Equals(DefaultHeaderColor1);
		}

		/// <summary>
		/// Indicates the designer whether <see cref="HeaderColor2"/> needs
		/// to be serialized.
		/// </summary>
		protected virtual bool ShouldSerializeHeaderColor2()
		{
			return !_headerColor2.Equals(DefaultHeaderColor2);
		}

		/// <summary>
		/// Indicates the designer whether <see cref="BorderColor"/> needs
		/// to be serialized.
		/// </summary>
		protected virtual bool ShouldSerializeBorderColor()
		{
			return !_borderColor.Equals(DefaultBorderColor);
		}

		#endregion

		#region Eventraisers

		/// <summary>
		/// Raises the <see cref="TextAlignChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnTextAlignChanged(EventArgs eventArgs)
		{
			if (TextAlignChanged != null)
				TextAlignChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="CanResizeChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnCanResizeChanged(EventArgs eventArgs)
		{
			if (CanResizeChanged != null)
				CanResizeChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="CanExpandCollapseChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnCanExpandCollapseChanged(EventArgs eventArgs)
		{
			if (CanExpandCollapseChanged != null)
				CanExpandCollapseChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="ShowExpandCollapseButtonChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnShowExpandCollapseButtonChanged(EventArgs eventArgs)
		{
			if (ShowExpandCollapseButtonChanged != null)
				ShowExpandCollapseButtonChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="ImagesEnabledChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnImagesEnabledChanged(EventArgs eventArgs)
		{
			if (ImagesEnabledChanged != null)
				ImagesEnabledChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="AnimationEnabledChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnAnimationEnabledChanged(EventArgs eventArgs)
		{
			if (AnimationEnabledChanged != null)
				AnimationEnabledChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="AnimationIntervallChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnAnimationIntervallChanged(EventArgs eventArgs)
		{
			if (AnimationIntervallChanged != null)
				AnimationIntervallChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="AnimationStepSizeChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnAnimationStepSizeChanged(EventArgs eventArgs)
		{
			if (AnimationStepSizeChanged != null)
				AnimationStepSizeChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="BorderColorChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnBorderColorChanged(EventArgs eventArgs)
		{
			if (BorderColorChanged != null)
				BorderColorChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="BorderWidthChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnBorderWidthChanged(EventArgs eventArgs)
		{
			if (BorderWidthChanged != null)
				BorderWidthChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="ButtonArrowColorChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnButtonArrowColorChanged(EventArgs eventArgs)
		{
			if (ButtonArrowColorChanged != null)
				ButtonArrowColorChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="ButtonHighlightAlphaChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnButtonHighlightAlphaChanged(EventArgs eventArgs)
		{
			if (ButtonHighlightAlphaChanged != null)
				ButtonHighlightAlphaChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="ButtonHighlightColorChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnButtonHighlightColorChanged(EventArgs eventArgs)
		{
			if (ButtonHighlightColorChanged != null)
				ButtonHighlightColorChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="HeaderColor1Changed"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnHeaderColor1Changed(EventArgs eventArgs)
		{
			if (HeaderColor1Changed != null)
				HeaderColor1Changed(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="HeaderColor2Changed"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnHeaderColor2Changed(EventArgs eventArgs)
		{
			if (HeaderColor2Changed != null)
				HeaderColor2Changed(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="HeaderGradientModeChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnHeaderGradientModeChanged(EventArgs eventArgs)
		{
			if (HeaderGradientModeChanged != null)
				HeaderGradientModeChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="HeaderHeightChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnHeaderHeightChanged(EventArgs eventArgs)
		{
			if (HeaderHeightChanged != null)
				HeaderHeightChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="MinimumExpandedHeightChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnMinimumExpandedHeightChanged(EventArgs eventArgs)
		{
			if (MinimumExpandedHeightChanged != null)
				MinimumExpandedHeightChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="BorderStyleChanged"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnBorderStyleChanged(EventArgs eventArgs)
		{
			if (BorderStyleChanged != null)
				BorderStyleChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="GroupPaneAdded"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnGroupPaneAdded(GroupPaneEventArgs eventArgs)
		{
			if (GroupPaneAdded != null)
				GroupPaneAdded(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="GroupPaneRemoved"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected void OnGroupPaneRemoved(GroupPaneEventArgs eventArgs)
		{
			if (GroupPaneRemoved != null)
				GroupPaneRemoved(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="GroupPaneCollapsing"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected virtual void OnGroupPaneCollapsing(GroupPaneCancelEventArgs eventArgs)
		{
			if (GroupPaneCollapsing != null)
				GroupPaneCollapsing(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="GroupPaneCollapsed"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected virtual void OnGroupPaneCollapsed(GroupPaneEventArgs eventArgs)
		{
			if (GroupPaneCollapsed != null)
				GroupPaneCollapsed(this, eventArgs);

			this.PerformLayout(null, "");
		}

		/// <summary>
		/// Raises the <see cref="GroupPaneExpanding"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected virtual void OnGroupPaneExpanding(GroupPaneCancelEventArgs eventArgs)
		{
			if (GroupPaneExpanding != null)
				GroupPaneExpanding(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="GroupPaneExpanded"/> event.
		/// </summary>
		/// <param name="eventArgs">Event data.</param>
		protected virtual void OnGroupPaneExpanded(GroupPaneEventArgs eventArgs)
		{
			if (GroupPaneExpanded != null)
				GroupPaneExpanded(this, eventArgs);
			
			this.PerformLayout(null, "");
		}

		#endregion

		#endregion

		#region Privates

		private void AutoCorrectMinimumExpandedHeight()
		{
			if (MinimumExpandedHeight < MinimumExpandedHeightInternal)
				MinimumExpandedHeight = MinimumExpandedHeightInternal;
		}
		
		private void ClearStringFormat()
		{
			if (_stringFormat != null)
			{
				_stringFormat.Dispose();
				_stringFormat = null;
			}
		}
		
		private StringFormat CreateStringFormat()
		{
			StringFormat stringFormat = new StringFormat();

			if ((this.TextAlign & (ContentAlignment.BottomRight | 
				ContentAlignment.MiddleRight | ContentAlignment.TopRight))
				!= (ContentAlignment)0)
				stringFormat.Alignment = StringAlignment.Far;
			else if ((this.TextAlign & (ContentAlignment.BottomCenter | 
				ContentAlignment.MiddleCenter | ContentAlignment.TopCenter))
				!= (ContentAlignment)0)
				stringFormat.Alignment = StringAlignment.Center;
			else
				stringFormat.Alignment = StringAlignment.Near;

			if ((this.TextAlign & (ContentAlignment.BottomRight | 
				ContentAlignment.BottomCenter | ContentAlignment.BottomLeft))
				!= (ContentAlignment)0)
				stringFormat.LineAlignment = StringAlignment.Far;
			else if ((this.TextAlign & (ContentAlignment.MiddleCenter | 
				ContentAlignment.MiddleLeft | ContentAlignment.MiddleRight))
				!= (ContentAlignment)0)
				stringFormat.LineAlignment = StringAlignment.Center;
			else
				stringFormat.LineAlignment = StringAlignment.Near;

			if (this.RightToLeft == RightToLeft.Yes)
				stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

			return stringFormat;
		}

		private void AdjustDockPadding()
		{
			foreach (Control control in Controls)
			{
				if (control as GroupPane != null)
					(control as GroupPane).AdjustDockPadding();
			}
		}

		#region Eventhandlers

		private void OnGroupPaneCollapsing(object sender, CancelEventArgs e)
		{
			OnGroupPaneCollapsing(new GroupPaneCancelEventArgs((GroupPane)sender));
		}

		private void OnGroupPaneCollapsed(object sender, EventArgs e)
		{
			OnGroupPaneCollapsed(new GroupPaneEventArgs((GroupPane)sender));
		}

		private void OnGroupPaneExpanding(object sender, CancelEventArgs e)
		{
			OnGroupPaneExpanding(new GroupPaneCancelEventArgs((GroupPane)sender));
		}

		private void OnGroupPaneExpanded(object sender, EventArgs e)
		{
			OnGroupPaneExpanded(new GroupPaneEventArgs((GroupPane)sender));
		}

		#endregion

		#endregion

		#region Overriden from Panel

		/// <summary>
		/// Reinitializes the internal string format of the text.
		/// </summary>
		/// <param name="e">Event data.</param>
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			ClearStringFormat();
		}

		/// <summary>
		/// Adjusts the scrollbars.
		/// Disabled while an animation is running.
		/// </summary>
		/// <param name="displayScrollbars">Sets wether the scrollbars should be visible or not.</param>
		protected override void AdjustFormScrollbars(bool displayScrollbars)
		{
			if (!IsAnimationRunning)
				base.AdjustFormScrollbars(displayScrollbars);
		}
		
		/// <summary>
		/// Gets the paramters for the control.
		/// </summary>
		protected override CreateParams CreateParams
		{
			[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.LinkDemand, UnmanagedCode = true)]
			get
			{
				CreateParams parameters = base.CreateParams;

				switch (_borderStyle)
				{
					case BorderStyle.FixedSingle:
					{
						parameters.Style |= 0x800000;
						break;
					}
					case BorderStyle.Fixed3D:
					{
						parameters.ExStyle |= 0x200;
						break;
					}
				} 

				return parameters;
			}
		}

		#endregion

		#region ISupportInitialize Member

		/// <summary>
		/// Signals the object the start of the initialization process.
		/// </summary>
		public void BeginInit() {}

		/// <summary>
		/// Signals the object the end of the initialization process.
		/// Adds some dummy groups at design time (just a visual gimmick).
		/// </summary>
		public void EndInit()
		{
			if (base.DesignMode)
			{
				for (int i = 0; i < 4; i++)
				{
					Panel p = new Panel();
					p.BackColor = Color.Transparent;
					Add(p, "Pane " + i, null);
				}
			}			
		}

		#endregion
	}
}
