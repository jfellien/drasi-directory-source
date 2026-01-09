IMAGE_NAME ?= directory-proxy

.PHONY: default docker-build kind-load

default: docker-build

docker-build:
	docker build -f Dockerfile -t $(IMAGE_NAME) ..

kind-load:
	kind load docker-image $(IMAGE_NAME) --name $(if $(CLUSTER_NAME),$(CLUSTER_NAME),kind)

k3d-load:
	k3d image import $(IMAGE_NAME) -c $(if $(CLUSTER_NAME),$(CLUSTER_NAME),k3s-default)