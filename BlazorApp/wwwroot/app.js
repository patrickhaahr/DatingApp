function initializeFilePond() {
    FilePond.registerPlugin(
        FilePondPluginFileValidateSize,
        FilePondPluginImagePreview,
        FilePondPluginFileValidateType
    );

    FilePond.create(document.querySelector('.file-pond-input'), {
        allowMultiple: true,
        acceptedFileTypes: ['image/png', 'image/jpeg'],
        allowFileSizeValidation: true,
        maxFileSize: '1MB',
        server: {
            process: {
                url: '/api/File/upload',
                method: "POST",
                withCredentials: false,
                headers: {},
                timeout: 7000
                onload: (response) => {
                    const fileUrl = response; // Handle the file URL returned from the server
                    dotNetHelper.invokeMethodAsync('SetProfileImageUrl', fileUrl); // Ensure namespace and method name match
            }
        }
    });

    FilePond.create(document.querySelector(".filepond-profile-image-input"), {
        labelIdle: `Drag & Drop or <span class="filepond--label-action">Browse</span>`,
        imagePreviewHeight: 170,
        imageCropAspectRatio: '1:1',
        imageResizeTargetWidth: 200,
        imageResizeTargetHeight: 200,
        stylePanelLayout: 'compact circle',
        styleLoadIndicatorPosition: 'center bottom',
        styleButtonRemoveItemPosition: 'center bottom',
        server: {
            process: {
                url: '/api/File/upload',
                method: "POST",
                withCredentials: false,
                headers: {},
                timeout: 7000
                onload: (response) => {
                    const fileUrl = response; // Handle the file URL returned from the server
                    dotNetHelper.invokeMethodAsync('SetProfileImageUrl', fileUrl); // Ensure namespace and method name match
            }
        }
    });
}