﻿using System;
using System.Windows.Forms;
using PatchApply;
using ResourceManager;

namespace GitUI.CommandsDialogs
{
    public partial class FormViewPatch : GitModuleForm
    {
        private readonly TranslationString _patchFileFilterString =
            new TranslationString("Patch file (*.Patch)");

        private readonly TranslationString _patchFileFilterTitle =
            new TranslationString("Select patch file");

        public FormViewPatch(GitUICommands commands)
            : base(commands)
        {
            InitializeComponent();
            Translate();

            PatchManager = new PatchManager();
        }

        public void LoadPatch(string patch)
        {
            PatchFileNameEdit.Text = patch;
            LoadPatchFile();
        }

        public PatchManager PatchManager { get; set; }

        private void GridChangedFiles_SelectionChanged(object sender, EventArgs e)
        {
            if (GridChangedFiles.SelectedRows.Count == 0)
            {
                return;
            }

            var patch = (Patch)GridChangedFiles.SelectedRows[0].DataBoundItem;

            if (patch == null)
            {
                return;
            }

            ChangesList.ViewPatch(patch);
        }

        private void BrowsePatch_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = _patchFileFilterString.Text + "|*.patch",
                InitialDirectory = @".",
                Title = _patchFileFilterTitle.Text
            };

            using (dialog)
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    PatchFileNameEdit.Text = dialog.FileName;
                }
            }

            LoadPatchFile();
        }

        private void LoadPatchFile()
        {
            try
            {
                PatchManager.LoadPatchFile(PatchFileNameEdit.Text, Module.FilesEncoding);

                GridChangedFiles.DataSource = PatchManager.Patches;
            }
            catch
            {
            }
        }
    }
}
