using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using transmission_renamer;
using Transmission.API.RPC.Entity;
using transmission_renamer.Classes;
using System.Threading.Tasks;
using System.Drawing;

class BufferedTreeView : TreeView
{

	private List<TreeNode> m_SelectedNodes = null;

	public List<TreeNode> SelectedNodes 
	{
		get
		{
			return m_SelectedNodes;
		}
		set
		{
			ClearSelectedNodes();
			if (value != null)
			{
				foreach (TreeNode node in value)
				{
					ToggleNode(node, true);
				}
			}
		}
	}

	// Note we use the new keyword to Hide the native treeview's 
	// SelectedNode property.
	private TreeNode m_SelectedNode;
	public new TreeNode SelectedNode
	{
		get
		{
			return m_SelectedNode;
		}
		set
		{
			ClearSelectedNodes();
			if (value != null)
			{
				SelectNode(value);
			}
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		// Make sure at least one node has a selection
		// this way we can tab to the ctrl and use the
		// keyboard to select nodes
		try
		{
			if (m_SelectedNode == null && this.TopNode != null)
			{
				ToggleNode(this.TopNode, true);
			}

			base.OnGotFocus(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		// If the user clicks on a node that was not
		// previously selected, select it now.
		try
		{
			base.SelectedNode = null;

			TreeNode node = this.GetNodeAt(e.Location);
			if (node != null)
			{
				//Allow user to click on image
				int leftBound = node.Bounds.X; // - 20; 
											   // Give a little extra room
				int rightBound = node.Bounds.Right + 10;
				if (e.Location.X > leftBound && e.Location.X < rightBound)
				{
					if (ModifierKeys ==
						Keys.None && (m_SelectedNodes.Contains(node)))
					{
						// Potential Drag Operation
						// Let Mouse Up do select
					}
					else
					{
						SelectNode(node);
					}
				}
			}

			base.OnMouseDown(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		// If you clicked on a node that WAS previously
		// selected then, reselect it now. This will clear
		// any other selected nodes. e.g. A B C D are selected
		// the user clicks on B, now A C & D are no longer selected.
		try
		{
			// Check to see if a node was clicked on
			TreeNode node = this.GetNodeAt(e.Location);
			if (node != null)
			{
				if (ModifierKeys == Keys.None && m_SelectedNodes.Contains(node))
				{
					// Allow user to click on image
					int leftBound = node.Bounds.X; // - 20; 
												   // Give a little extra room
					int rightBound = node.Bounds.Right + 10;
					if (e.Location.X > leftBound && e.Location.X < rightBound)
					{
						SelectNode(node);
					}
				}
			}

			base.OnMouseUp(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnItemDrag(ItemDragEventArgs e)
	{
		// If the user drags a node and the node being dragged is NOT
		// selected, then clear the active selection, select the
		// node being dragged and drag it. Otherwise if the node being
		// dragged is selected, drag the entire selection.
		try
		{
			TreeNode node = e.Item as TreeNode;

			if (node != null)
			{
				if (!m_SelectedNodes.Contains(node))
				{
					SelectSingleNode(node);
					ToggleNode(node, true);
				}
			}

			base.OnItemDrag(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
	{
		// Never allow base.SelectedNode to be set!
		try
		{
			base.SelectedNode = null;
			e.Cancel = true;

			base.OnBeforeSelect(e);
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override async void OnAfterSelect(TreeViewEventArgs e)
	{
		// Never allow base.SelectedNode to be set!
		try
		{
			base.OnAfterSelect(e);
			base.SelectedNode = null;
			await UpdateCounters();
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		// Handle all possible key strokes for the control.
		// including navigation, selection, etc.

		base.OnKeyDown(e);

		if (e.KeyCode == Keys.ShiftKey) return;

		//this.BeginUpdate();
		bool bShift = (ModifierKeys == Keys.Shift);

		try
		{
			// Nothing is selected in the tree, this isn't a good state
			// select the top node
			if (m_SelectedNode == null && this.TopNode != null)
			{
				ToggleNode(this.TopNode, true);
			}

			// Nothing is still selected in the tree, 
			// this isn't a good state, leave.
			if (m_SelectedNode == null) return;

			if (e.KeyCode == Keys.Left)
			{
				if (m_SelectedNode.IsExpanded && m_SelectedNode.Nodes.Count > 0)
				{
					// Collapse an expanded node that has children
					m_SelectedNode.Collapse();
				}
				else if (m_SelectedNode.Parent != null)
				{
					// Node is already collapsed, try to select its parent.
					SelectSingleNode(m_SelectedNode.Parent);
				}
			}
			else if (e.KeyCode == Keys.Right)
			{
				if (!m_SelectedNode.IsExpanded)
				{
					// Expand a collapsed node's children
					m_SelectedNode.Expand();
				}
				else
				{
					// Node was already expanded, select the first child
					SelectSingleNode(m_SelectedNode.FirstNode);
				}
			}
			else if (e.KeyCode == Keys.Up)
			{
				// Select the previous node
				if (m_SelectedNode.PrevVisibleNode != null)
				{
					SelectNode(m_SelectedNode.PrevVisibleNode);
				}
			}
			else if (e.KeyCode == Keys.Down)
			{
				// Select the next node
				if (m_SelectedNode.NextVisibleNode != null)
				{
					SelectNode(m_SelectedNode.NextVisibleNode);
				}
			}
			else if (e.KeyCode == Keys.Home)
			{
				if (bShift)
				{
					if (m_SelectedNode.Parent == null)
					{
						// Select all of the root nodes up to this point
						if (this.Nodes.Count > 0)
						{
							SelectNode(this.Nodes[0]);
						}
					}
					else
					{
						// Select all of the nodes up to this point under 
						// this nodes parent
						SelectNode(m_SelectedNode.Parent.FirstNode);
					}
				}
				else
				{
					// Select this first node in the tree
					if (this.Nodes.Count > 0)
					{
						SelectSingleNode(this.Nodes[0]);
					}
				}
			}
			else if (e.KeyCode == Keys.End)
			{
				if (bShift)
				{
					if (m_SelectedNode.Parent == null)
					{
						// Select the last ROOT node in the tree
						if (this.Nodes.Count > 0)
						{
							SelectNode(this.Nodes[this.Nodes.Count - 1]);
						}
					}
					else
					{
						// Select the last node in this branch
						SelectNode(m_SelectedNode.Parent.LastNode);
					}
				}
				else
				{
					if (this.Nodes.Count > 0)
					{
						// Select the last node visible node in the tree.
						// Don't expand branches incase the tree is virtual
						TreeNode ndLast = this.Nodes[0].LastNode;
						while (ndLast.IsExpanded && (ndLast.LastNode != null))
						{
							ndLast = ndLast.LastNode;
						}
						SelectSingleNode(ndLast);
					}
				}
			}
			else if (e.KeyCode == Keys.PageUp)
			{
				// Select the highest node in the display
				int nCount = this.VisibleCount;
				TreeNode ndCurrent = m_SelectedNode;
				while ((nCount) > 0 && (ndCurrent.PrevVisibleNode != null))
				{
					ndCurrent = ndCurrent.PrevVisibleNode;
					nCount--;
				}
				SelectSingleNode(ndCurrent);
			}
			else if (e.KeyCode == Keys.PageDown)
			{
				// Select the lowest node in the display
				int nCount = this.VisibleCount;
				TreeNode ndCurrent = m_SelectedNode;
				while ((nCount) > 0 && (ndCurrent.NextVisibleNode != null))
				{
					ndCurrent = ndCurrent.NextVisibleNode;
					nCount--;
				}
				SelectSingleNode(ndCurrent);
			}
			else
			{
				// Assume this is a search character a-z, A-Z, 0-9, etc.
				// Select the first node after the current node that
				// starts with this character
				string sSearch = ((char)e.KeyValue).ToString();

				TreeNode ndCurrent = m_SelectedNode;
				while ((ndCurrent.NextVisibleNode != null))
				{
					ndCurrent = ndCurrent.NextVisibleNode;
					if (ndCurrent.Text.StartsWith(sSearch))
					{
						SelectSingleNode(ndCurrent);
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			HandleException(ex);
		}
		finally
		{
			this.EndUpdate();
		}
	}

	private void SelectNode(TreeNode node)
	{
		try
		{
			this.BeginUpdate();

			if (m_SelectedNode == null || ModifierKeys == Keys.Control)
			{
				// Ctrl+Click selects an unselected node, 
				// or unselects a selected node.
				bool bIsSelected = m_SelectedNodes.Contains(node);
				ToggleNode(node, !bIsSelected);
			}
			else if (ModifierKeys == Keys.Shift)
			{
				// Shift+Click selects nodes between the selected node and here.
				TreeNode ndStart = m_SelectedNode;
				TreeNode ndEnd = node;

				if (ndStart.Parent == ndEnd.Parent)
				{
					// Selected node and clicked node have same parent, easy case.
					if (ndStart.Index < ndEnd.Index)
					{
						// If the selected node is beneath 
						// the clicked node walk down
						// selecting each Visible node until we reach the end.
						while (ndStart != ndEnd)
						{
							ndStart = ndStart.NextVisibleNode;
							if (ndStart == null) break;
							ToggleNode(ndStart, true);
						}
					}
					else if (ndStart.Index == ndEnd.Index)
					{
						// Clicked same node, do nothing
					}
					else
					{
						// If the selected node is above the clicked node walk up
						// selecting each Visible node until we reach the end.
						while (ndStart != ndEnd)
						{
							ndStart = ndStart.PrevVisibleNode;
							if (ndStart == null) break;
							ToggleNode(ndStart, true);
						}
					}
				}
				else
				{
					// Selected node and clicked node have same parent, hard case.
					// We need to find a common parent to determine if we need
					// to walk down selecting, or walk up selecting.

					TreeNode ndStartP = ndStart;
					TreeNode ndEndP = ndEnd;
					int startDepth = Math.Min(ndStartP.Level, ndEndP.Level);

					// Bring lower node up to common depth
					while (ndStartP.Level > startDepth)
					{
						ndStartP = ndStartP.Parent;
					}

					// Bring lower node up to common depth
					while (ndEndP.Level > startDepth)
					{
						ndEndP = ndEndP.Parent;
					}

					// Walk up the tree until we find the common parent
					while (ndStartP.Parent != ndEndP.Parent)
					{
						ndStartP = ndStartP.Parent;
						ndEndP = ndEndP.Parent;
					}

					// Select the node
					if (ndStartP.Index < ndEndP.Index)
					{
						// If the selected node is beneath 
						// the clicked node walk down
						// selecting each Visible node until we reach the end.
						while (ndStart != ndEnd)
						{
							ndStart = ndStart.NextVisibleNode;
							if (ndStart == null) break;
							ToggleNode(ndStart, true);
						}
					}
					else if (ndStartP.Index == ndEndP.Index)
					{
						if (ndStart.Level < ndEnd.Level)
						{
							while (ndStart != ndEnd)
							{
								ndStart = ndStart.NextVisibleNode;
								if (ndStart == null) break;
								ToggleNode(ndStart, true);
							}
						}
						else
						{
							while (ndStart != ndEnd)
							{
								ndStart = ndStart.PrevVisibleNode;
								if (ndStart == null) break;
								ToggleNode(ndStart, true);
							}
						}
					}
					else
					{
						// If the selected node is above 
						// the clicked node walk up
						// selecting each Visible node until we reach the end.
						while (ndStart != ndEnd)
						{
							ndStart = ndStart.PrevVisibleNode;
							if (ndStart == null) break;
							ToggleNode(ndStart, true);
						}
					}
				}
			}
			else
			{
				// Just clicked a node, select it
				SelectSingleNode(node);
			}

			OnAfterSelect(new TreeViewEventArgs(m_SelectedNode));
		}
		finally
		{
			this.EndUpdate();
		}
	}

	private async void ClearSelectedNodes()
	{
		try
		{
			m_SelectedNodes.Clear();
			m_SelectedNode = null;
			await UpdateCounters();
		}
		finally
		{
			m_SelectedNodes.Clear();
			m_SelectedNode = null;
		}
	}

	private void SelectSingleNode(TreeNode node)
	{
		if (node == null)
		{
			return;
		}

		ClearSelectedNodes();
		ToggleNode(node, true);
		node.EnsureVisible();
	}

	private void ToggleNode(TreeNode node, bool bSelectNode)
	{
		if (bSelectNode)
		{
			m_SelectedNode = node;
			if (!m_SelectedNodes.Contains(node))
			{
				m_SelectedNodes.Add(node);
			}
			node.BackColor = SystemColors.Highlight;
            node.ForeColor = SystemColors.HighlightText;
        }
		else
		{
			m_SelectedNodes.Remove(node);
            //node.BackColor = this.BackColor;
            //node.ForeColor = this.ForeColor;
        }
	}

	private void HandleException(Exception ex)
	{
		// Perform some error handling here.
		// We don't want to bubble errors to the CLR.
		MessageBox.Show(ex.Message);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
		base.OnHandleCreated(e);
	}
	// Pinvoke:
	private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
    private const int TVS_EX_DOUBLEBUFFER = 0x0004;
	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 0x0203)
		{
			m.Msg = 0x0201;
		}
		base.WndProc(ref m);
	}

	public int TotalFiles = 0;
	public int TotalFilesSelected = 0;


	// <remarks>
	// CheckedState is an enum of all allowable nodes states
	// </remarks>
	public enum CheckedState : int { UnInitialised = -1, UnChecked, Checked, Mixed };

	// <remarks>
	// IgnoreClickAction is used to ingore messages generated by setting the node.Checked flag in code
	// Do not set <c>e.Cancel = true</c> in <c>OnBeforeCheck</c> otherwise the Checked state will be lost
	// </remarks>
	int IgnoreClickAction = 0;
	// <remarks>

	// TriStateStyles is an enum of all allowable tree styles
	// All styles check children when parent is checked
	// Installer automatically checks parent if all children are checked, and unchecks parent if at least one child is unchecked
	// Standard never changes the checked status of a parent
	// </remarks>
	public enum TriStateStyles : int { Standard = 0, Installer };

	// Create a private member for the tree style, and allow it to be set on the property sheer
	private TriStateStyles TriStateStyle = TriStateStyles.Standard;

	[System.ComponentModel.Category("Tri-State Tree View")]
	[System.ComponentModel.DisplayName("Style")]
	[System.ComponentModel.Description("Style of the Tri-State Tree View")]
	public TriStateStyles TriStateStyleProperty
	{
		get { return TriStateStyle; }
		set { TriStateStyle = value; }
	}

	// <summary>
	// Constructor.  Create and populate an image list
	// </summary>
	public BufferedTreeView() : base()
	{
		StateImageList = new System.Windows.Forms.ImageList();

		// populate the image list, using images from the System.Windows.Forms.CheckBoxRenderer class
		for (int i = 0; i < 3; i++)
		{
			// Create a bitmap which holds the relevent check box style
			// see http://msdn.microsoft.com/en-us/library/ms404307.aspx and http://msdn.microsoft.com/en-us/library/system.windows.forms.checkboxrenderer.aspx

			System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(16, 16);
			System.Drawing.Graphics chkGraphics = System.Drawing.Graphics.FromImage(bmp);
			switch (i)
			{
				case 0:
					System.Windows.Forms.CheckBoxRenderer.DrawCheckBox(chkGraphics, new System.Drawing.Point(0, 0), System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
					break;
				case 1:
					System.Windows.Forms.CheckBoxRenderer.DrawCheckBox(chkGraphics, new System.Drawing.Point(0, 0), System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
					break;
				case 2:
					System.Windows.Forms.CheckBoxRenderer.DrawCheckBox(chkGraphics, new System.Drawing.Point(0, 0), System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal);
					break;
			}

			StateImageList.Images.Add(bmp);
		}
		m_SelectedNodes = new List<TreeNode>();
		base.SelectedNode = null;
	}

	// <summary>
	// Called once before window displayed.  Disables default Checkbox functionality and ensures all nodes display an 'unchecked' image.
	// </summary>
	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		CheckBoxes = false;         // Disable default CheckBox functionality if it's been enabled

		// Give every node an initial 'unchecked' image
		IgnoreClickAction++;    // we're making changes to the tree, ignore any other change requests
		UpdateChildState(this.Nodes, (int)CheckedState.UnChecked, false, true);
		IgnoreClickAction--;
	}

	// <summary>
	// Called after a node is checked.  Forces all children to inherit current state, and notifies parents they may need to become 'mixed'
	// </summary>
	protected override void OnAfterCheck(System.Windows.Forms.TreeViewEventArgs e)
	{
		base.OnAfterCheck(e);

		if (IgnoreClickAction > 0)
		{
			return;
		}

		IgnoreClickAction++;    // we're making changes to the tree, ignore any other change requests

		// the checked state has already been changed, we just need to update the state index

		// node is either ticked or unticked.  ignore mixed state, as the node is still only ticked or unticked regardless of state of children
		System.Windows.Forms.TreeNode tn = e.Node;
		tn.StateImageIndex = tn.Checked ? (int)CheckedState.Checked : (int)CheckedState.UnChecked;

		// force all children to inherit the same state as the current node
		UpdateChildState(e.Node.Nodes, e.Node.StateImageIndex, e.Node.Checked, false);
		// populate state up the tree, possibly resulting in parents with mixed state
		UpdateParentState(e.Node.Parent);
		IgnoreClickAction--;
	}

	public IEnumerable<TreeNode> GetAllNodes(TreeNodeCollection nodes)
	{
		foreach (TreeNode node in nodes)
		{
			yield return node;

			foreach (var child in GetAllNodes(node.Nodes))
				yield return child;
		}
	}
	public async Task UpdateCounters()
	{

		Globals.SelectedTorrentFiles.Clear();
		TotalFiles = 0;
		TotalFilesSelected = 0;
		foreach (var node in GetAllNodes(Nodes))
		{
			if (!SelectedNodes.Contains(node))
			{
				if (node.StateImageIndex == (int)CheckedState.UnChecked)
					node.BackColor = Color.FromArgb(255, 235, 235);
				else
					node.BackColor = Color.FromArgb(235, 255, 235);
				node.ForeColor = this.ForeColor;
			}
			if (node.Tag is FriendlyTorrentFileInfo info)
			{
				TotalFiles++;
				if (node.Checked)
				{
					TotalFilesSelected++;
					Globals.SelectedTorrentFiles.Add(info);
				}
			}
		}

        SettingsForm parent = (SettingsForm)FindForm();
		if (parent != null)
			await parent.UpdateCheckedFileCountStatus();
    }

    // <summary>
    // Called after a node is expanded.  Ensures any new nodes display an 'unchecked' image
    // </summary>
    protected override void OnAfterExpand(System.Windows.Forms.TreeViewEventArgs e)
	{
		// If any child node is new, give it the same check state as the current node
		// So if current node is ticked, child nodes will also be ticked
		base.OnAfterExpand(e);

		IgnoreClickAction++;    // we're making changes to the tree, ignore any other change requests
		UpdateChildState(e.Node.Nodes, e.Node.StateImageIndex, e.Node.Checked, true);
		IgnoreClickAction--;
	}

	// <summary>
	// Helper function to replace child state with that of the parent
	// </summary>
	protected void UpdateChildState(System.Windows.Forms.TreeNodeCollection Nodes, int StateImageIndex, bool Checked, bool ChangeUninitialisedNodesOnly)
	{
		BeginUpdate();
		foreach (System.Windows.Forms.TreeNode tnChild in Nodes)
		{
			if (!ChangeUninitialisedNodesOnly || tnChild.StateImageIndex == -1)
			{
				tnChild.StateImageIndex = StateImageIndex;
				tnChild.Checked = Checked;  // override 'checked' state of child with that of parent
				if (tnChild.Nodes.Count > 0)
				{
					UpdateChildState(tnChild.Nodes, StateImageIndex, Checked, ChangeUninitialisedNodesOnly);
				}
			}
		}
		EndUpdate();
	}

	// <summary>
	// Helper function to notify parent it may need to use 'mixed' state
	// </summary>
	public void UpdateParentState(System.Windows.Forms.TreeNode tn)
	{
		// Node needs to check all of it's children to see if any of them are ticked or mixed
		if (tn == null)
			return;

		int OrigStateImageIndex = tn.StateImageIndex;

		int UnCheckedNodes = 0, CheckedNodes = 0, MixedNodes = 0;

		// The parent needs to know how many of it's children are Checked or Mixed

		foreach (System.Windows.Forms.TreeNode tnChild in tn.Nodes)
		{
			if (tnChild.StateImageIndex == (int)CheckedState.Checked)
				CheckedNodes++;
            else if (tnChild.StateImageIndex == (int)CheckedState.Mixed)
            {
                MixedNodes++;
                break;
            }
            else
                UnCheckedNodes++;
		}

		if (TriStateStyle == TriStateStyles.Installer)
		{
			// In Installer mode, if all child nodes are checked then parent is checked
			// If at least one child is unchecked, then parent is unchecked
			if (MixedNodes == 0)
			{
				if (UnCheckedNodes == 0)
				{
					// all children are checked, so parent must be checked
					tn.Checked = true;
				}
				else
				{
					// at least one child is unchecked, so parent must be unchecked
					tn.Checked = false;
				}
			}
		}

		// Determine the parent's new Image State
		if (MixedNodes > 0)
		{
			// at least one child is mixed, so parent must be mixed
			tn.StateImageIndex = (int)CheckedState.Mixed;
		}
		else if (CheckedNodes > 0 && UnCheckedNodes == 0)
		{
			// all children are checked
			if (tn.Checked)
				tn.StateImageIndex = (int)CheckedState.Checked;
			else
				tn.StateImageIndex = (int)CheckedState.UnChecked;
		}
		else if (CheckedNodes > 0 && UnCheckedNodes >= 0)
		{
			// some children are checked, the rest are unchecked
			tn.StateImageIndex = (int)CheckedState.Mixed;
		}
		else
		{
			// all children are unchecked
			tn.StateImageIndex = (int)CheckedState.UnChecked;
		}

		if (OrigStateImageIndex != tn.StateImageIndex && tn.Parent != null)
		{
			// Parent's state has changed, notify the parent's parent
			UpdateParentState(tn.Parent);
		}
	}

	// <summary>
	// Called on keypress.  Used to change node state when Space key is pressed
	// Invokes OnAfterCheck to do the real work
	// </summary>
	//protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
	//{
	//	base.OnKeyDown(e);

	//	//// is the keypress a space?  If not, discard it
	//	//if (e.KeyCode == System.Windows.Forms.Keys.Space)
	//	//{
	//	//	// toggle the node's checked status.  This will then fire OnAfterCheck
	//	//	SelectedNode.Checked = !SelectedNode.Checked;
	//	//}
	//}

	// <summary>
	// Called when node is clicked by the mouse.  Does nothing unless the image was clicked
	// Invokes OnAfterCheck to do the real work
	// </summary>
	protected override async void OnNodeMouseClick(System.Windows.Forms.TreeNodeMouseClickEventArgs e)
    {
        base.OnNodeMouseClick(e);
        if (e.Button == MouseButtons.Right)
        {
            System.Windows.Forms.TreeViewHitTestInfo info = HitTest(e.X, e.Y);
            if (info.Location == TreeViewHitTestLocations.Label || info.Location == TreeViewHitTestLocations.RightOfLabel)
            {
                this.SelectedNode = e.Node;
                return;
            }

        }

        // toggle the node's checked status.  This will then fire OnAfterCheck
        System.Windows.Forms.TreeNode tn = e.Node;

        if (tn.Tag.ToString() != "Folder")
        {
			if (SelectedNode != tn && SelectedNodes.Contains(tn) == false)
			{
				tn.Checked = !tn.Checked;
				await UpdateCounters();
			}
        }
        else
        {
            // is the click on the checkbox?  If not, discard it
            System.Windows.Forms.TreeViewHitTestInfo info = HitTest(e.X, e.Y);
            if (info == null || info.Location != System.Windows.Forms.TreeViewHitTestLocations.StateImage)
                return;
            else
            {
                tn.Checked = !tn.Checked;
                await UpdateCounters();
            }
        }
    }

}