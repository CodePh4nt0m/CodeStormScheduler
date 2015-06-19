calendarModule.factory("calendarServices", ['$resource',
    function($resource) {
        var host = '';
        var demoUrl = '';

        return {
            demoService: function() {
                return $resource(host + demoUrl, {}, {
                    query: {
                        method: 'GET',
                        isArray: true
                    },
                    create: {
                        method: 'POST'
                    }
                });
            }
        }
    }
]);