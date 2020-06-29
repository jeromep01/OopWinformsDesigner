namespace OopWinformsDesigner.UI.UserControls
{
    partial class MainLayout
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.sccGeneric = new DevExpress.XtraEditors.SplitContainerControl();
            this.sccPanelControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.panelDesignerHost = new DevExpress.XtraEditors.PanelControl();
            this.sccDesignerHostAndTools = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.sccGeneric)).BeginInit();
            this.sccGeneric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccPanelControl)).BeginInit();
            this.sccPanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDesignerHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccDesignerHostAndTools)).BeginInit();
            this.sccDesignerHostAndTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            this.SuspendLayout();
            // 
            // sccGeneric
            // 
            this.sccGeneric.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sccGeneric.Appearance.Options.UseBackColor = true;
            this.sccGeneric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccGeneric.Location = new System.Drawing.Point(0, 0);
            this.sccGeneric.Name = "sccGeneric";
            this.sccGeneric.Panel1.Controls.Add(this.sccPanelControl);
            this.sccGeneric.Panel1.Text = "Panel1";
            this.sccGeneric.Panel2.Controls.Add(this.sccDesignerHostAndTools);
            this.sccGeneric.Panel2.Text = "Panel2";
            this.sccGeneric.Size = new System.Drawing.Size(853, 431);
            this.sccGeneric.SplitterPosition = 200;
            this.sccGeneric.TabIndex = 0;
            // 
            // sccPanelControl
            // 
            this.sccPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccPanelControl.Horizontal = false;
            this.sccPanelControl.Location = new System.Drawing.Point(0, 0);
            this.sccPanelControl.Name = "sccPanelControl";
            this.sccPanelControl.Panel1.Controls.Add(this.treeList1);
            this.sccPanelControl.Panel1.Text = "Panel1";
            this.sccPanelControl.Panel2.Controls.Add(this.propertyGridControl1);
            this.sccPanelControl.Panel2.Text = "Panel2";
            this.sccPanelControl.Size = new System.Drawing.Size(200, 431);
            this.sccPanelControl.SplitterPosition = 189;
            this.sccPanelControl.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(200, 189);
            this.treeList1.TabIndex = 0;
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.Size = new System.Drawing.Size(200, 232);
            this.propertyGridControl1.TabIndex = 0;
            // 
            // panelDesignerHost
            // 
            this.panelDesignerHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesignerHost.Location = new System.Drawing.Point(0, 0);
            this.panelDesignerHost.Name = "panelDesignerHost";
            this.panelDesignerHost.Size = new System.Drawing.Size(600, 431);
            this.panelDesignerHost.TabIndex = 0;
            // 
            // sccDesignerHostAndTools
            // 
            this.sccDesignerHostAndTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccDesignerHostAndTools.Location = new System.Drawing.Point(0, 0);
            this.sccDesignerHostAndTools.Name = "sccDesignerHostAndTools";
            this.sccDesignerHostAndTools.Panel1.Controls.Add(this.panelDesignerHost);
            this.sccDesignerHostAndTools.Panel1.Text = "Panel1";
            this.sccDesignerHostAndTools.Panel2.Controls.Add(this.treeList2);
            this.sccDesignerHostAndTools.Panel2.Text = "Panel2";
            this.sccDesignerHostAndTools.Size = new System.Drawing.Size(643, 431);
            this.sccDesignerHostAndTools.SplitterPosition = 600;
            this.sccDesignerHostAndTools.TabIndex = 1;
            // 
            // treeList2
            // 
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList2.Location = new System.Drawing.Point(0, 0);
            this.treeList2.Name = "treeList2";
            this.treeList2.Size = new System.Drawing.Size(33, 431);
            this.treeList2.TabIndex = 0;
            // 
            // MainLayout
            // 
            this.Appearance.BackColor = System.Drawing.Color.Green;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sccGeneric);
            this.Name = "MainLayout";
            this.Size = new System.Drawing.Size(853, 431);
            ((System.ComponentModel.ISupportInitialize)(this.sccGeneric)).EndInit();
            this.sccGeneric.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccPanelControl)).EndInit();
            this.sccPanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDesignerHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccDesignerHostAndTools)).EndInit();
            this.sccDesignerHostAndTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sccGeneric;
        private DevExpress.XtraEditors.PanelControl panelDesignerHost;
        private DevExpress.XtraEditors.SplitContainerControl sccPanelControl;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.SplitContainerControl sccDesignerHostAndTools;
        private DevExpress.XtraTreeList.TreeList treeList2;
    }
}
