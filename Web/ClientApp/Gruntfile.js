grunt.loadNpmTasks('grunt-package-minifier');
grunt.initConfig({
  package_minifier: {
    your_target: {
      target: '', // (optional) Entry point (e.g 'browser') to use, when present, instead of 'main' (the default)
      src: [], // Path to package.json files for modules to be minified
      dest: '' // Target directory for minified modules.
    },
  },
})
