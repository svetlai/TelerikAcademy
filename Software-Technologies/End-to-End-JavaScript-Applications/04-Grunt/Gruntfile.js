module.exports = function(grunt) {
	grunt.initConfig({
		jade: {
			compile: {
				files: {
					'dev/index.html': 'app/index.jade'
				}
			}
		},
		coffee: {
			compile: {
				files: {
					'dev/scripts/script.js': 'app/script.coffee'
				}
			}
		},
		stylus: {
			compile: {
				files: {
					'dev/styles/site.css': 'app/site.styl',
				}
			}
		},
		jshint: {
			all: ['Gruntfile.js', 'app/**/*.js']
		},
		copy: {
			main: {
				cwd: 'app/images/',
				src: ['**'],
				expand: true,
				flatten: true,
				dest: 'dev/images'
			}
		},
		connect: {
			options: {
				port: 9578,
				livereload: 35729,
				hostname: 'localhost'
			},
			livereload: {
				options: {
					open: true,
					base: [
						'dev'
					]
				}
			}
		},
		watch: {
			js: {
				files: ['Gruntfile.js', 'app/**/*.coffee'],
				tasks: ['coffee'],
				options: {
					livereload: true
				}
			},
			stylus: {
				files: ['app/**/*.styl'],
				tasks: ['stylus'],
				options: {
					livereload: true
				}
			},
			jade: {
				files: ['app/index.jade'],
				tasks: ['jade'],
				options: {
					livereload: true
				}
			},
			livereload: {
				options: {
					livereload: 35729
				},
				files: [
					'dev/scripts/*.js'
				],
				tasks: ['jshint']
			}
		}
	});

	grunt.loadNpmTasks('grunt-contrib-coffee');
	grunt.loadNpmTasks('grunt-contrib-jshint');
	grunt.loadNpmTasks('grunt-contrib-jade');
	grunt.loadNpmTasks('grunt-contrib-stylus');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks('grunt-contrib-connect');
	grunt.loadNpmTasks('grunt-contrib-watch');

	grunt.registerTask('default', ['coffee', 'jshint', 'jade', 'stylus', 'copy', 'connect', 'watch']);
};