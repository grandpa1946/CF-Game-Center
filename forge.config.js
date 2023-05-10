module.exports = {
  packagerConfig: {},
  rebuildConfig: {},
  makers: [
    {
      name: '@electron-forge/maker-squirrel',
      config: {},
    },
    {
      name: '@electron-forge/maker-deb',
      config: {},
    },
    {
      name: '@electron-forge/maker-rpm',
      config: {},
    },
    {
      name: '@electron-forge/maker-zip'
      "platforms": [
          "windows"
       ]
    },
    {
      name: '@electron-forge/maker-squirrel',
      config: {
        authors: 'Zortos and Kief',
        description: 'Cloudforce Game Center'
      },
      
    },
  ],
};
